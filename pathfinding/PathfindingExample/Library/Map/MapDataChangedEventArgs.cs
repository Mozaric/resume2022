using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.Map
{
	public class MapDataChangedEventArgs : EventArgs
	{
		public Point Point { get; private set; } = new Point();
		public int X { get { return Point.X; } }
		public int Y { get { return Point.Y; } }
		public EMapObject NewMapData { get; private set; } = EMapObject.None;

		public MapDataChangedEventArgs(Point Point, EMapObject NewMapData) : this(Point.X, Point.Y, NewMapData)
		{

		}
		public MapDataChangedEventArgs(int X, int Y, EMapObject NewMapData)
		{
			this.Point = new Point(X, Y);
			this.NewMapData = NewMapData;
		}
	}
}
