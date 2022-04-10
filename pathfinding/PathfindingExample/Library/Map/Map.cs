using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.Map
{
	public class Map : IMap
	{
		// [多維陣列 (C# 程式設計手冊)](https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)
		// int[,] array2D = new int[4, 2]
		// {
		// 		{ 1, 2 },
		// 		{ 3, 4 },
		// 		{ 5, 6 },
		// 		{ 7, 8 }
		// };

		public event EventHandler<MapDataChangedEventArgs> MapDataChanged;

		public int Width { get; private set; } = 0;
		public int Height { get; private set; } = 0;

		private EMapObject[,] MapData = null;

		public Map(int Width, int Height)
		{
			Set(Width, Height);
		}
		public void Set(int Width, int Height)
		{
			if (Width <= 0 || Height <= 0) return;

			this.Width = Width;
			this.Height = Height;
			MapData = new EMapObject[Height, Width];

			// Initialize Map Data
			for (int y = 0; y < Height; ++y)
			{
				for (int x = 0; x < Width; ++x)
				{
					// Set Wall
					if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
					{
						MapData[y, x] = EMapObject.Obstacle;
					}
					// Set Space
					else
					{
						MapData[y, x] = EMapObject.Space;
					}
				}
			}
		}
		public EMapObject GetMapData(Point Point)
		{
			return GetMapData(Point.X, Point.Y);
		}
		public EMapObject GetMapData(int X, int Y)
		{
			if (X >= 0 && X < Width && Y >= 0 && Y < Height)
			{
				return MapData[Y, X];
			}
			else
			{
				return EMapObject.None;
			}
		}
		public void SetMapData(Point Point, EMapObject MapObject)
		{
			SetMapData(Point.X, Point.Y, MapObject);
		}
		public void SetMapData(int X, int Y, EMapObject MapObject)
		{
			if (X >= 0 && X < Width && Y >= 0 && Y < Height)
			{
				MapData[Y, X] = MapObject;
				RaiseEvent_MapDataChanged(new MapDataChangedEventArgs(X, Y, MapData[Y, X]));
			}
		}
		public void PrintToConsole()
		{
			for (int y = 0; y < Height; ++y)
			{
				for (int x = 0; x < Width; ++x)
				{
					Console.Write((int)MapData[y, x] + " ");
				}
				Console.WriteLine("");
			}
		}

		private void RaiseEvent_MapDataChanged(MapDataChangedEventArgs MapDataChangedEventArgs)
		{
			MapDataChanged?.Invoke(this, MapDataChangedEventArgs);
		}
	}
}
