using PathfindingExample.Library.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public class PathFinderUsingAStar : IPathFinderWithPathScoring
	{
		// [A*路徑搜尋初探 GameDev.net](https://swf.com.tw/?p=67)

		public event EventHandler<NodeListCountChanged> OpenNodeListItemAdded;
		public event EventHandler<NodeListCountChanged> OpenNodeListItemRemoved;
		public event EventHandler<NodeListCountChanged> CloseNodeListItemAdded;
		public event EventHandler<NodeListCountChanged> CloseNodeListItemRemoved;

		public IMap Map { get; private set; }

		public static PathFinderUsingAStar Instance = new PathFinderUsingAStar();

		protected int HMagnification = 10;
		protected int GDirect = 10;
		protected int GOblique = 14;
		protected List<Node> OpenNodeList = new List<Node>();
		protected List<Node> CloseNodeList = new List<Node>();

		public PathFinderUsingAStar()
		{

		}
		public void Set(IMap Map)
		{
			this.Map = Map;
		}
		public List<Point> FindPath(Point StartPoint, Point EndPoint)
		{
			List<Point> result = null;

			// Initialization
			OpenNodeList.Clear();
			CloseNodeList.Clear();
			OpenNodeList.Add(new Node(null, StartPoint, 0, 0));

			// Main Loop
			// 如果仍有點尚未探索，則繼續尋路
			while (OpenNodeList.Any())
			{
				// 取出愈探索的點
				Node currentNode = TakeNodeFromOpenNodeList();
				// 並標記此點已探索
				AddNodeToCloseNodeList(currentNode);
				// 如果當前點即為終點，代表尋路成功，停止運算
				if (IsEqual(currentNode.Point, EndPoint))
				{
					break;
				}
				// 反之，將周遭點加入尚未探索的清單中，以繼續進行尋路
				{
					AddSuccessorNodeToOpenNodeList(currentNode, EndPoint);
				}
			}

			// 如果尋路成功
			if (IsPointInCloseNodeList(EndPoint))
			{
				result = GetFullPathPoints(GetCorrespondingNodeFromCloseNodeList(EndPoint));
			}
			// 如果尋路失敗
			else
			{
				result = null;
			}

			return result;
		}

		protected virtual Node TakeNodeFromOpenNodeList()
		{
			Node result = OpenNodeList.First();
			OpenNodeList.RemoveAt(0);
			RaiseEvent_OpenNodeListItemRemoved(new NodeListCountChanged(result));
			return result;
		}
		protected virtual void AddSuccessorNodeToOpenNodeList(Node Node, Point EndPoint)
		{
			List<Node> successorNodes = GetNeighborNodes(Node, EndPoint);
			foreach (Node successorNode in successorNodes)
			{
				// 尚未探索過，且該處為 Space 的點，才能加入 OpenNodeList
				if (!IsPointInCloseNodeList(successorNode.Point) && Map.GetMapData(successorNode.Point) == EMapObject.Space)
				{
					AddNodeToOpenNodeList(successorNode);
				}
			}
		}
		protected virtual void AddNodeToOpenNodeList(Node Node)
		{
			// 如果此 Node 已經存在於 OpenNodeList 中
			if (IsPointInOpenNodeList(Node.Point))
			{
				Node oldNode = GetCorrespondingNodeFromOpenNodeList(Node.Point);
				// 若新的 Node 的 G 值較小，則移除舊的 Node ，以讓新的 Node 加入至 OpenNodeList 中
				if (Node.G < oldNode.G)
				{
					OpenNodeList.Remove(oldNode);
				}
				// 反之，不修改 OpenNodeList
				else
				{
					return;
				}
			}

			// 根據 Node 的 F 值的大小將新的 Node 加入
			bool inserted = false;
			for (int i = 0; i < OpenNodeList.Count; ++i)
			{
				if (Node.F <= OpenNodeList[i].F)
				{
					OpenNodeList.Insert(i, Node);
					inserted = true;
					break;
				}
			}
			if (!inserted) OpenNodeList.Add(Node);

			RaiseEvent_OpenNodeListItemAdded(new NodeListCountChanged(Node));
		}
		protected virtual void AddNodeToCloseNodeList(Node Node)
		{
			CloseNodeList.Add(Node);
			RaiseEvent_CloseNodeListItemAdded(new NodeListCountChanged(Node));
		}
		protected virtual List<Node> GetNeighborNodes(Node Node, Point EndPoint)
		{
			List<Node> result = new List<Node>();
			List<Point> neighborPoints = GetNeighborPoints(Node, EndPoint);
			foreach (Point neighborPoint in neighborPoints)
			{
				int G = CalculateG(Node.Point, neighborPoint) + Node.G;
				int H = CalculateH(neighborPoint, EndPoint);
				result.Add(new Node(Node, neighborPoint, G, H));
			}
			return result;
		}
		protected virtual List<Point> GetNeighborPoints(Node Node, Point EndPoint)
		{
			List<Point> result = new List<Point>();
			result.Add(new Point(Node.Point.X + 1, Node.Point.Y + 0));
			result.Add(new Point(Node.Point.X + 1, Node.Point.Y + 1));
			result.Add(new Point(Node.Point.X + 0, Node.Point.Y + 1));
			result.Add(new Point(Node.Point.X - 1, Node.Point.Y + 1));
			result.Add(new Point(Node.Point.X - 1, Node.Point.Y + 0));
			result.Add(new Point(Node.Point.X - 1, Node.Point.Y - 1));
			result.Add(new Point(Node.Point.X + 0, Node.Point.Y - 1));
			result.Add(new Point(Node.Point.X + 1, Node.Point.Y - 1));
			return result;
		}
		protected virtual int CalculateG(Point Point1, Point Point2)
		{
			if (Math.Abs(Point1.X - Point2.X) + Math.Abs(Point1.Y - Point2.Y) == 2)
			{
				return GOblique;
			}
			else
			{
				return GDirect;
			}
		}
		protected virtual int CalculateH(Point Point1, Point Point2)
		{
			return (Math.Abs(Point1.X - Point2.X) + Math.Abs(Point1.Y - Point2.Y)) * HMagnification;
		}
		protected virtual bool IsPointInOpenNodeList(Point Point)
		{
			return OpenNodeList.Any(o => o.X == Point.X && o.Y == Point.Y);
		}
		protected virtual bool IsPointInCloseNodeList(Point Point)
		{
			return CloseNodeList.Any(o => o.X == Point.X && o.Y == Point.Y);
		}
		protected virtual Node GetCorrespondingNodeFromOpenNodeList(Point Point)
		{
			return OpenNodeList.FirstOrDefault(o => o.X == Point.X && o.Y == Point.Y);
		}
		protected virtual Node GetCorrespondingNodeFromCloseNodeList(Point Point)
		{
			return CloseNodeList.FirstOrDefault(o => o.X == Point.X && o.Y == Point.Y);
		}
		protected virtual List<Point> GetFullPathPoints(Node Node)
		{
			List<Point> result = new List<Point>();
			Node tmp = Node;
			while (tmp != null)
			{
				result.Insert(0, tmp.Point);
				tmp = tmp.Parent;
			}
			return result;
		}
		protected virtual bool IsEqual(Point Point1, Point Point2)
		{
			return Point1.X == Point2.X && Point1.Y == Point2.Y;
		}
		protected virtual void RaiseEvent_OpenNodeListItemAdded(NodeListCountChanged EventArgs)
		{
			OpenNodeListItemAdded?.Invoke(this, EventArgs);
		}
		protected virtual void RaiseEvent_OpenNodeListItemRemoved(NodeListCountChanged EventArgs)
		{
			OpenNodeListItemRemoved?.Invoke(this, EventArgs);
		}
		protected virtual void RaiseEvent_CloseNodeListItemAdded(NodeListCountChanged EventArgs)
		{
			CloseNodeListItemAdded?.Invoke(this, EventArgs);
		}
		protected virtual void RaiseEvent_CloseNodeListItemRemoved(NodeListCountChanged EventArgs)
		{
			CloseNodeListItemRemoved?.Invoke(this, EventArgs);
		}
	}
}
