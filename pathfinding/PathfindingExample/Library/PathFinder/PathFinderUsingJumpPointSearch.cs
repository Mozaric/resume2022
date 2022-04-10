using PathfindingExample.Library.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public class PathFinderUsingJumpPointSearch : PathFinderUsingAStar, IPathFinderWithPathScoring
	{
		// [Jump Point Search](https://harablog.wordpress.com/2011/09/07/jump-point-search/)

		public static new PathFinderUsingJumpPointSearch Instance = new PathFinderUsingJumpPointSearch();

		public PathFinderUsingJumpPointSearch() : base()
		{

		}

		protected override List<Point> GetNeighborPoints(Node Node, Point EndPoint)
		{
			if (Node.Parent == null)
			{
				return base.GetNeighborPoints(Node, EndPoint);
			}
			else
			{
				int diffX = Node.X - Node.Parent.X;
				int diffY = Node.Y - Node.Parent.Y;
				if (diffX != 0) diffX = diffX / Math.Abs(diffX);
				if (diffY != 0) diffY = diffY / Math.Abs(diffY);

				List<Point> neighborPoints = new List<Point>();
				if (diffX != 0 && diffY != 0) // Parent 到 Node 的移動方向為斜向
				{
					if (Map.GetMapData(Node.X + diffX, Node.Y) == EMapObject.Space) // Natural Neighbor
					{
						neighborPoints.Add(new Point(Node.X + diffX, Node.Y));
					}
					if (Map.GetMapData(Node.X, Node.Y + diffY) == EMapObject.Space) // Natural Neighbor
					{
						neighborPoints.Add(new Point(Node.X, Node.Y + diffY));
					}
					if (Map.GetMapData(Node.X + diffX, Node.Y + diffY) == EMapObject.Space) // Natural Neighbor
					{
						neighborPoints.Add(new Point(Node.X + diffX, Node.Y + diffY));
					}
					if (Map.GetMapData(Node.X - diffX, Node.Y) == EMapObject.Obstacle && Map.GetMapData(Node.X - diffX, Node.Y + diffY) == EMapObject.Space) // Forced Neighbor
					{
						neighborPoints.Add(new Point(Node.X - diffX, Node.Y + diffY));
					}
					if (Map.GetMapData(Node.X, Node.Y - diffY) == EMapObject.Obstacle && Map.GetMapData(Node.X + diffX, Node.Y - diffY) == EMapObject.Space) // Forced Neighbor
					{
						neighborPoints.Add(new Point(Node.X + diffX, Node.Y - diffY));
					}
				}
				else if (diffX != 0 && diffY == 0) // Parent 到 Node 的移動方向為橫向
				{
					if (Map.GetMapData(Node.X + diffX, Node.Y) == EMapObject.Space) // Natural Neighbor
					{
						neighborPoints.Add(new Point(Node.X + diffX, Node.Y));

						if (Map.GetMapData(Node.X, Node.Y + 1) == EMapObject.Obstacle && Map.GetMapData(Node.X + diffX, Node.Y + 1) == EMapObject.Space) // Forced Neighbor
						{
							neighborPoints.Add(new Point(Node.X + diffX, Node.Y + 1));
						}
						if (Map.GetMapData(Node.X, Node.Y - 1) == EMapObject.Obstacle && Map.GetMapData(Node.X + diffX, Node.Y - 1) == EMapObject.Space) // Forced Neighbor
						{
							neighborPoints.Add(new Point(Node.X + diffX, Node.Y - 1));
						}
					}
				}
				else if (diffX == 0 && diffY != 0) // Parent 到 Node 的移動方向為直向
				{
					if (Map.GetMapData(Node.X, Node.Y + diffY) == EMapObject.Space)
					{
						neighborPoints.Add(new Point(Node.X, Node.Y + diffY));

						if (Map.GetMapData(Node.X + 1, Node.Y) == EMapObject.Obstacle && Map.GetMapData(Node.X + 1, Node.Y + diffY) == EMapObject.Space) // Forced Neighbor
						{
							neighborPoints.Add(new Point(Node.X + 1, Node.Y + diffY));
						}
						if (Map.GetMapData(Node.X - 1, Node.Y) == EMapObject.Obstacle && Map.GetMapData(Node.X - 1, Node.Y + diffY) == EMapObject.Space) // Forced Neighbor
						{
							neighborPoints.Add(new Point(Node.X - 1, Node.Y + diffY));
						}
					}
				}

				List<Point> result = new List<Point>();
				if (neighborPoints.Count > 0)
				{
					foreach (Point neighborPoint in neighborPoints)
					{
						Point jumpPoint = Jump(Node.Point, neighborPoint, EndPoint);
						if (jumpPoint != default(Point))
						{
							result.Add(jumpPoint);
						}
					}
				}
				return result;
			}
		}
		protected override int CalculateG(Point Point1, Point Point2)
		{
			return (int)Math.Sqrt((Point1.X - Point2.X) * (Point1.X - Point2.X) + (Point1.Y - Point2.Y) * (Point1.Y - Point2.Y)) * HMagnification;
		}

		private Point Jump(Point Current, Point Neighbor, Point End)
		{
			if (Map.GetMapData(Neighbor.X, Neighbor.Y) == EMapObject.Obstacle)
			{
				return default(Point);
			}
			if (Neighbor.X == End.X && Neighbor.Y == End.Y)
			{
				return Neighbor;
			}

			int diffX = Neighbor.X - Current.X;
			int diffY = Neighbor.Y - Current.Y;
			if (diffX != 0 && diffY != 0) // Current 到 Neighbor 的移動方向為斜向
			{
				if (Map.GetMapData(Neighbor.X - diffX, Neighbor.Y) == EMapObject.Obstacle && Map.GetMapData(Neighbor.X - diffX, Neighbor.Y + diffY) == EMapObject.Space)
				{
					return Neighbor;
				}
				if (Map.GetMapData(Neighbor.X, Neighbor.Y - diffY) == EMapObject.Obstacle && Map.GetMapData(Neighbor.X + diffX, Neighbor.Y - diffY) == EMapObject.Space)
				{
					return Neighbor;
				}

				if (Jump(Neighbor, new Point(Neighbor.X + diffX, Neighbor.Y), End) != default(Point) || Jump(Neighbor, new Point(Neighbor.X, Neighbor.Y + diffY), End) != default(Point))
				{
					return Neighbor;
				}
			}
			else if (diffX != 0 && diffY == 0) // Current 到 Neighbor 的移動方向為橫向
			{
				if (Map.GetMapData(Neighbor.X, Neighbor.Y + 1) == EMapObject.Obstacle && Map.GetMapData(Neighbor.X + diffX, Neighbor.Y + 1) == EMapObject.Space)
				{
					return Neighbor;
				}
				if (Map.GetMapData(Neighbor.X, Neighbor.Y - 1) == EMapObject.Obstacle && Map.GetMapData(Neighbor.X + diffX, Neighbor.Y - 1) == EMapObject.Space)
				{
					return Neighbor;
				}
			}
			else if (diffX == 0 && diffY != 0) // Current 到 Neighbor 的移動方向為直向
			{
				if (Map.GetMapData(Neighbor.X + 1, Neighbor.Y) == EMapObject.Obstacle && Map.GetMapData(Neighbor.X + 1, Neighbor.Y + diffY) == EMapObject.Space)
				{
					return Neighbor;
				}
				if (Map.GetMapData(Neighbor.X - 1, Neighbor.Y) == EMapObject.Obstacle && Map.GetMapData(Neighbor.X - 1, Neighbor.Y + diffY) == EMapObject.Space)
				{
					return Neighbor;
				}
			}

			return Jump(Neighbor, new Point(Neighbor.X + diffX, Neighbor.Y + diffY), End);
		}
	}
}
