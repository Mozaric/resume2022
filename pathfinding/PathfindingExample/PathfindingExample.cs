using PathfindingExample.Library;
using PathfindingExample.Library.Map;
using PathfindingExample.Library.PathFinder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathfindingExample
{
	public enum SetMapObjectMode
	{
		None,
		SetObstacle,
		SetSpace,
		SetStartPoint,
		SetEndPoint
	}

	public partial class PathfindingExample : Form
	{
		private IMap Map = null;
		private IPathFinderWithPathScoring PathFinder = null;
		private Point StartPoint = default(Point);
		private Point EndPoint = default(Point);
		private Path Path = null;
		private SetMapObjectMode SetMapObjectMode = SetMapObjectMode.None;

		private static Color ColorOfGridLine = Color.DimGray;
		private static Color ColorOfSpace = Color.FromArgb(30, 30, 30);
		private static Color ColorOfObstacle = Color.FromArgb(0, 0, 150);
		private static Color ColorOfStartPoint = Color.Green;
		private static Color ColorOfEndPoint = Color.Red;
		private static Color ColorOfOpenNode = Color.LightPink;
		private static Color ColorOfCloseNode = Color.LightGreen;
		private static Color ColorOfPathLine = Color.DarkOrange;

		public PathfindingExample()
		{
			InitializeComponent();
		}

		protected void SetObstacle(int X, int Y)
		{
			// 不在 StartPoint, EndPoint 的位置設定
			if (X == StartPoint.X && Y == StartPoint.Y) return;
			if (X == EndPoint.X && Y == EndPoint.Y) return;

			Map.SetMapData(X, Y, EMapObject.Obstacle);
		}
		protected void SetSpace(int X, int Y)
		{
			// 不在 StartPoint, EndPoint 的位置設定
			if (X == StartPoint.X && Y == StartPoint.Y) return;
			if (X == EndPoint.X && Y == EndPoint.Y) return;
			// 不在邊界設定
			if (X == 0 || X == Map.Width - 1) return;
			if (Y == 0 || Y == Map.Height - 1) return;

			Map.SetMapData(X, Y, EMapObject.Space);
		}
		protected void SetStartPoint(int X, int Y)
		{
			// 不在邊界設定
			if (X <= 0 || X >= Map.Width - 1) return;
			if (Y <= 0 || Y >= Map.Height - 1) return;
			// 不在 Obstacle 上設定
			if (Map.GetMapData(X, Y) == EMapObject.Obstacle) return;
			// 不在 EndPoint 上設定
			if (X == EndPoint.X && Y == EndPoint.Y) return;

			if (StartPoint != default(Point) && !(X == StartPoint.X && Y == StartPoint.Y))
			{
				Draw_FillGrid(StartPoint.X, StartPoint.Y, ColorOfSpace);
			}
			StartPoint = new Point(X, Y);
			Draw_FillGrid(StartPoint.X, StartPoint.Y, ColorOfStartPoint);
		}
		protected void SetEndPoint(int X, int Y)
		{
			// 不在邊界設定
			if (X <= 0 || X >= Map.Width - 1) return;
			if (Y <= 0 || Y >= Map.Height - 1) return;
			// 不在 Obstacle 上設定
			if (Map.GetMapData(X, Y) == EMapObject.Obstacle) return;
			// 不在 StartPoint 上設定
			if (X == StartPoint.X && Y == StartPoint.Y) return;

			if (EndPoint != default(Point) && !(X == EndPoint.X && Y == EndPoint.Y))
			{
				Draw_FillGrid(EndPoint.X, EndPoint.Y, ColorOfSpace);
			}
			EndPoint = new Point(X, Y);
			Draw_FillGrid(EndPoint.X, EndPoint.Y, ColorOfEndPoint);
		}
		protected void UpdateGui_DgvLog_Initialize()
		{
			DataGridView dgv = dgvLog;

			dgv.SelectionChanged += ((sender, e) => dgv.ClearSelection());

			dgv.RowHeadersVisible = false;
			dgv.ColumnHeadersVisible = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToResizeRows = false;
			dgv.AllowUserToResizeColumns = false;
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.MultiSelect = false;
			dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
			dgv.GridColor = Color.FromArgb(50, 50, 50);
			dgv.BorderStyle = BorderStyle.None;

			dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
			dgv.DefaultCellStyle.ForeColor = Color.White;

			dgv.Columns.Add("Date", "Date");
			dgv.Columns[0].Width = 70;
			dgv.Columns.Add("Message", "Message");
			dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			foreach (DataGridViewColumn column in dgv.Columns)
			{
				column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
				column.ReadOnly = true;
			}
		}
		protected void UpdateGui_DgvLog_AddLog(string Log)
		{
			dgvLog.InvokeIfNecessary(() =>
			{
				if (dgvLog.RowCount > 2) dgvLog.Rows.RemoveAt(dgvLog.RowCount - 1);
				dgvLog.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss.fff"), Log);
			});
		}
		protected void Draw_BuildImageOfIMap()
		{
			if (Map == null) return;

			pbMap.Image = Draw_BuildImageOfIMap(pbMap.Width, pbMap.Height, Map);
			if (StartPoint != default(Point)) SetStartPoint(StartPoint.X, StartPoint.Y);
			if (EndPoint != default(Point)) SetEndPoint(EndPoint.X, EndPoint.Y);
		}
		protected void Draw_FillGrid(Point Point, Color Color)
		{
			Draw_FillGrid(Point.X, Point.Y, Color);
		}
		protected void Draw_FillGrid(int X, int Y, Color Color)
		{
			Draw_FillGrid(pbMap.Width, pbMap.Height, Map, pbMap.Image, X, Y, Color);
			pbMap.Refresh();
		}
		protected void Draw_DrawPath()
		{
			Draw_DrawPath(pbMap.Width, pbMap.Height, Map, pbMap.Image, Path);
			pbMap.Refresh();
		}
		protected void ConvertIndex(int CanvasX, int CanvasY, out int MapX, out int MapY)
		{
			ConvertIndex(pbMap.Width, pbMap.Height, Map, CanvasX, CanvasY, out MapX, out MapY);
		}

		private void Construct()
		{
			// Initialization of interface
			rdoAStar.Checked = true;
			UpdateGui_DgvLog_Initialize();

			// Initialization of internal object
			UnsubscribeEvent_IMap(Map);
			Map = new Map(45, 15);
			SubscribeEvent_IMap(Map);
			PathFinderUsingAStar.Instance.Set(Map);
			PathFinderUsingJumpPointSearch.Instance.Set(Map);
			Path = new Path();
			Draw_BuildImageOfIMap();
			SetStartPoint(1, 1);
			SetEndPoint(Map.Width - 2, Map.Height - 2);
		}
		private void Destruct()
		{

		}
		private void SubscribeEvent_IMap(IMap Map)
		{
			if (Map != null)
			{
				Map.MapDataChanged += HandleEvent_MapMapDataChanged;
			}
		}
		private void UnsubscribeEvent_IMap(IMap Map)
		{
			if (Map != null)
			{
				Map.MapDataChanged -= HandleEvent_MapMapDataChanged;
			}
		}
		private void SubscribeEvent_IPathFinderWithPathScoring(IPathFinderWithPathScoring PathFinder)
		{
			if (PathFinder != null)
			{
				PathFinder.OpenNodeListItemAdded += HandleEvent_PathFinderOpenNodeListItemAdded;
				PathFinder.OpenNodeListItemRemoved += HandleEvent_PathFinderOpenNodeListItemRemoved;
				PathFinder.CloseNodeListItemAdded += HandleEvent_PathFinderCloseNodeListItemAdded;
				PathFinder.CloseNodeListItemRemoved += HandleEvent_PathFinderCloseNodeListItemRemoved;
			}
		}
		private void UnsubscribeEvent_IPathFinderWithPathScoring(IPathFinderWithPathScoring PathFinder)
		{
			if (PathFinder != null)
			{
				PathFinder.OpenNodeListItemAdded -= HandleEvent_PathFinderOpenNodeListItemAdded;
				PathFinder.OpenNodeListItemRemoved -= HandleEvent_PathFinderOpenNodeListItemRemoved;
				PathFinder.CloseNodeListItemAdded -= HandleEvent_PathFinderCloseNodeListItemAdded;
				PathFinder.CloseNodeListItemRemoved -= HandleEvent_PathFinderCloseNodeListItemRemoved;
			}
		}
		private void HandleEvent_MapMapDataChanged(object sender, MapDataChangedEventArgs e)
		{
			switch (e.NewMapData)
			{
				case EMapObject.None:
					break;
				case EMapObject.Space:
					Draw_FillGrid(e.Point, ColorOfSpace);
					break;
				case EMapObject.Obstacle:
					Draw_FillGrid(e.Point, ColorOfObstacle);
					break;
				default:
					break;
			}
		}
		private void HandleEvent_PathFinderOpenNodeListItemAdded(object sender, NodeListCountChanged e)
		{
			// 不在 StartPoint, EndPoint 的位置設定
			if (e.Node.Point.X == StartPoint.X && e.Node.Point.Y == StartPoint.Y) return;
			if (e.Node.Point.X == EndPoint.X && e.Node.Point.Y == EndPoint.Y) return;

			Draw_FillGrid(e.Node.Point, ColorOfOpenNode);
		}
		private void HandleEvent_PathFinderOpenNodeListItemRemoved(object sender, NodeListCountChanged e)
		{
			// 不在 StartPoint, EndPoint 的位置設定
			if (e.Node.Point.X == StartPoint.X && e.Node.Point.Y == StartPoint.Y) return;
			if (e.Node.Point.X == EndPoint.X && e.Node.Point.Y == EndPoint.Y) return;

			Draw_FillGrid(e.Node.Point, ColorOfSpace);
		}
		private void HandleEvent_PathFinderCloseNodeListItemAdded(object sender, NodeListCountChanged e)
		{
			// 不在 StartPoint, EndPoint 的位置設定
			if (e.Node.Point.X == StartPoint.X && e.Node.Point.Y == StartPoint.Y) return;
			if (e.Node.Point.X == EndPoint.X && e.Node.Point.Y == EndPoint.Y) return;

			Draw_FillGrid(e.Node.Point, ColorOfCloseNode);
		}
		private void HandleEvent_PathFinderCloseNodeListItemRemoved(object sender, NodeListCountChanged e)
		{
			// 不在 StartPoint, EndPoint 的位置設定
			if (e.Node.Point.X == StartPoint.X && e.Node.Point.Y == StartPoint.Y) return;
			if (e.Node.Point.X == EndPoint.X && e.Node.Point.Y == EndPoint.Y) return;

			Draw_FillGrid(e.Node.Point, ColorOfSpace);
		}
		private void PathfindingExample_Load(object sender, EventArgs e)
		{
			Construct();
		}
		private void PathfindingExample_FormClosing(object sender, FormClosingEventArgs e)
		{
			Destruct();
		}
		private void ctrlTitle_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(Handle, 0x112, 0xf012, 0);
		}
		private void btnInformation_Click(object sender, EventArgs e)
		{
			formInformation form = new formInformation();
			form.ShowDialog();
		}
		private void btnMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void pbMap_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Color color = (pbMap.Image as Bitmap).GetPixel(e.X, e.Y);
				if (IsEqual(color, ColorOfSpace))
				{
					SetMapObjectMode = SetMapObjectMode.SetObstacle;
				}
				else if (IsEqual(color, ColorOfObstacle))
				{
					SetMapObjectMode = SetMapObjectMode.SetSpace;
				}
				else if (IsEqual(color, ColorOfStartPoint))
				{
					SetMapObjectMode = SetMapObjectMode.SetStartPoint;
				}
				else if (IsEqual(color, ColorOfEndPoint))
				{
					SetMapObjectMode = SetMapObjectMode.SetEndPoint;
				}
			}
		}
		private void pbMap_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				SetMapObjectMode = SetMapObjectMode.None;
			}
		}
		private void pbMap_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ConvertIndex(e.X, e.Y, out int MapX, out int MapY);
				switch (SetMapObjectMode)
				{
					case SetMapObjectMode.None:
						break;
					case SetMapObjectMode.SetObstacle:
						SetObstacle(MapX, MapY);
						break;
					case SetMapObjectMode.SetSpace:
						SetSpace(MapX, MapY);
						break;
					case SetMapObjectMode.SetStartPoint:
						SetStartPoint(MapX, MapY);
						break;
					case SetMapObjectMode.SetEndPoint:
						SetEndPoint(MapX, MapY);
						break;
					default:
						break;
				}
			}
		}
		private void rdoAlgorithm_CheckedChanged(object sender, EventArgs e)
		{
			Draw_BuildImageOfIMap();
			UnsubscribeEvent_IPathFinderWithPathScoring(PathFinder);
			if (rdoAStar.Checked)
			{
				PathFinder = PathFinderUsingAStar.Instance;
			}
			else if (rdoJPS.Checked)
			{
				PathFinder = PathFinderUsingJumpPointSearch.Instance;
			}
			SubscribeEvent_IPathFinderWithPathScoring(PathFinder);
		}
		private void btnFindPath_Click(object sender, EventArgs e)
		{
			Draw_BuildImageOfIMap();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			List<Point> pathPoints = PathFinder.FindPath(StartPoint, EndPoint);
			sw.Stop();
			string log = $"({StartPoint.X},{StartPoint.Y})-->({EndPoint.X},{EndPoint.Y}), ";
			if (pathPoints == null || pathPoints.Count == 0)
			{
				log += $"PathNotFound with {(rdoAStar.Checked ? "AStar" : "JPS")}, Cost: {(int)sw.Elapsed.TotalMilliseconds} ms";
			}
			else
			{
				Path.Set(pathPoints);
				log += $"PathFound with {(rdoAStar.Checked ? "AStar" : "JPS")}, Odo: {Path.Odometer}, Cost: {(int)sw.Elapsed.TotalMilliseconds} ms";
				Draw_DrawPath();
			}
			UpdateGui_DgvLog_AddLog(log);
		}

		private static void ConvertIndex(int CanvasWidth, int CanvasHeight, IMap Map, int CanvasX, int CanvasY, out int MapX, out int MapY)
		{
			MapX = -1;
			MapY = -1;

			int gridLineWidth = 1;
			int gridWidth = (CanvasWidth - (gridLineWidth * Map.Width)) / Map.Width;
			int gridHeight = (CanvasHeight - (gridLineWidth * Map.Height)) / Map.Height;
			int originalX = (CanvasWidth - gridLineWidth * Map.Width - gridWidth * Map.Width) / 2;
			int originalY = (CanvasHeight - gridLineWidth * Map.Height - gridHeight * Map.Height) / 2;

			int tmpMapX = (CanvasX - originalX) / (gridLineWidth + gridWidth);
			int tmpMapY = (CanvasY - originalY) / (gridLineWidth + gridHeight);
			if (tmpMapX < Map.Width && tmpMapY < Map.Height)
			{
				MapX = tmpMapX;
				MapY = tmpMapY;
			}
		}
		private static Image Draw_BuildImageOfIMap(int CanvasWidth, int CanvasHeight, IMap Map)
		{
			Bitmap result = new Bitmap(CanvasWidth, CanvasHeight);
			Graphics canvasGraphics = Graphics.FromImage(result);

			int gridLineWidth = 1;
			int gridWidth = (CanvasWidth - (gridLineWidth * Map.Width)) / Map.Width;
			int gridHeight = (CanvasHeight - (gridLineWidth * Map.Height)) / Map.Height;
			int originalX = (CanvasWidth - gridLineWidth * Map.Width - gridWidth * Map.Width) / 2;
			int originalY = (CanvasHeight - gridLineWidth * Map.Height - gridHeight * Map.Height) / 2;

			canvasGraphics.Clear(ColorOfSpace);

			// draw grid line
			using (Brush brush = new SolidBrush(ColorOfGridLine))
			{
				using (Pen pen = new Pen(brush, gridLineWidth))
				{
					for (int i = 0; i <= Map.Width; ++i)
					{
						int x = originalX + i * (gridLineWidth + gridWidth);
						int yTop = originalY;
						int yBottom = originalY + Map.Height * (gridLineWidth + gridHeight);
						canvasGraphics.DrawLine(pen, x, yTop, x, yBottom);
					}
					for (int i = 0; i <= Map.Height; ++i)
					{
						int xLeft = originalX;
						int xRight = originalX + Map.Width * (gridLineWidth + gridWidth);
						int y = originalY + i * (gridLineWidth + gridHeight);
						canvasGraphics.DrawLine(pen, xLeft, y, xRight, y);
					}
				}
			}

			// fill grid
			using (Brush brush = new SolidBrush(ColorOfObstacle))
			{
				for (int i = 0; i < Map.Width; ++i)
				{
					for (int j = 0; j < Map.Height; ++j)
					{
						if (Map.GetMapData(i, j) == EMapObject.Obstacle)
						{
							int x = originalX + i * (gridLineWidth + gridWidth) + gridLineWidth;
							int y = originalY + j * (gridLineWidth + gridHeight) + gridLineWidth;
							int width = gridWidth;
							int height = gridHeight;
							canvasGraphics.FillRectangle(brush, x, y, width, height);
						}
					}
				}
			}

			return result;
		}
		private static void Draw_FillGrid(int CanvasWidth, int CanvasHeight, IMap Map, Image Image, int X, int Y, Color Color)
		{
			int gridLineWidth = 1;
			int gridWidth = (CanvasWidth - (gridLineWidth * Map.Width)) / Map.Width;
			int gridHeight = (CanvasHeight - (gridLineWidth * Map.Height)) / Map.Height;
			int originalX = (CanvasWidth - gridLineWidth * Map.Width - gridWidth * Map.Width) / 2;
			int originalY = (CanvasHeight - gridLineWidth * Map.Height - gridHeight * Map.Height) / 2;
			Graphics canvasGraphics = Graphics.FromImage(Image);

			using (Brush brush = new SolidBrush(Color))
			{
				int x = originalX + X * (gridLineWidth + gridWidth) + gridLineWidth;
				int y = originalY + Y * (gridLineWidth + gridHeight) + gridLineWidth;
				int width = gridWidth;
				int height = gridHeight;
				canvasGraphics.FillRectangle(brush, x, y, width, height);
			}
		}
		private static void Draw_DrawPath(int CanvasWidth, int CanvasHeight, IMap Map, Image Image, Path Path)
		{
			int gridLineWidth = 3;
			int gridWidth = (CanvasWidth - (gridLineWidth * Map.Width)) / Map.Width;
			int gridHeight = (CanvasHeight - (gridLineWidth * Map.Height)) / Map.Height;
			int originalX = (CanvasWidth - gridLineWidth * Map.Width - gridWidth * Map.Width) / 2;
			int originalY = (CanvasHeight - gridLineWidth * Map.Height - gridHeight * Map.Height) / 2;
			Graphics canvasGraphics = Graphics.FromImage(Image);

			using (Brush brush = new SolidBrush(ColorOfPathLine))
			{
				using (Pen pen = new Pen(brush, gridLineWidth))
				{
					for (int i = 0; i < Path.PathPoints.Count - 1; ++i)
					{
						int x1 = originalX + Path.PathPoints[i].X * (gridLineWidth + gridWidth) + gridLineWidth + gridWidth / 2;
						int y1 = originalY + Path.PathPoints[i].Y * (gridLineWidth + gridHeight) + gridLineWidth + gridHeight / 2;
						int x2 = originalX + Path.PathPoints[i + 1].X * (gridLineWidth + gridWidth) + gridLineWidth + gridWidth / 2;
						int y2 = originalY + Path.PathPoints[i + 1].Y * (gridLineWidth + gridHeight) + gridLineWidth + gridHeight / 2;
						canvasGraphics.DrawLine(pen, x1, y1, x2, y2);
					}
				}
			}
		}
		private static bool IsEqual(Color Color1, Color Color2)
		{
			return Color1.R == Color2.R && Color1.G == Color2.G && Color1.B == Color2.B;
		}

		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
	}
}
