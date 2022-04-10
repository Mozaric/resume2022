using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public class Node
	{
		public Node Parent { get; private set; }
		public Point Point { get; private set; } = new Point();
		public int X { get { return Point.X; } }
		public int Y { get { return Point.Y; } }
		public int F { get { return G + H; } }
		public int G { get; private set; } = 0; // movement cost
		public int H { get; private set; } = 0; // heuristic
		public MoveDirection MoveDirection { get; private set; } = MoveDirection.None;

		public Node(Node Parent, Point Point, int G, int H) : this(Parent, Point.X, Point.Y, G, H)
		{

		}
		public Node(Node Parent, int X, int Y, int G, int H)
		{
			this.Parent = Parent;
			this.Point = new Point(X, Y);
			this.G = G;
			this.H = H;
			if (Parent != null) this.MoveDirection = CalculateMoveDirection(this.Parent.Point, this.Point);
		}

		private MoveDirection CalculateMoveDirection(Point Point1, Point Point2)
		{
			int diffX = Point2.X - Point1.X;
			int diffY = Point2.Y - Point1.Y;

			if (diffX == 0 && diffY == 0)
			{
				return MoveDirection.None;
			}
			else if (diffX > 0 && diffY == 0)
			{
				return MoveDirection.Right;
			}
			else if (diffX > 0 && diffY > 0)
			{
				return MoveDirection.RightTop;
			}
			else if (diffX == 0 && diffY > 0)
			{
				return MoveDirection.Top;
			}
			else if (diffX < 0 && diffY > 0)
			{
				return MoveDirection.LeftTop;
			}
			else if (diffX < 0 && diffY == 0)
			{
				return MoveDirection.Left;
			}
			else if (diffX < 0 && diffY < 0)
			{
				return MoveDirection.LeftBottom;
			}
			else if (diffX == 0 && diffY < 0)
			{
				return MoveDirection.Bottom;
			}
			else if (diffX > 0 && diffY < 0)
			{
				return MoveDirection.RightBottom;
			}
			else
			{
				return MoveDirection.None;
			}
		}
	}
}
