using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public class Path
	{
		public Point StartPoint { get { return PathPoints.First(); } }
		public Point EndPoint { get { return PathPoints.Last(); } }
		public List<Point> PathPoints { get; private set; } = new List<Point>();
		public int Odometer { get; private set; } = 0;

		public Path()
		{

		}
		public Path(List<Point> PathPoints)
		{
			Set(PathPoints);
		}
		public void Set(List<Point> PathPoints)
		{
			this.PathPoints.Clear();
			this.PathPoints.AddRange(PathPoints);
			this.Odometer = CalculateOdometer(this.PathPoints);
		}
		public override string ToString()
		{
			return $"Path:{ConvertToString(StartPoint)}->{ConvertToString(EndPoint)},Odo:{Odometer}";
		}

		private static int CalculateOdometer(List<Point> PathPoints)
		{
			double result = 0;
			for (int i = 0; i < PathPoints.Count - 1; ++i)
			{
				result += CalculateDistance(PathPoints[i], PathPoints[i + 1]);
			}
			return (int)result;
		}
		private static double CalculateDistance(Point Point1, Point Point2)
		{
			int diffX = Point1.X - Point2.X;
			int diffY = Point1.Y - Point2.Y;
			return Math.Sqrt(diffX * diffX + diffY * diffY);
		}
		private static string ConvertToString(Point Point)
		{
			return $"({Point.X},{Point.Y})";
		}
	}
}
