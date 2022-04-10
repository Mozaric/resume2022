using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.Map
{
	public interface IMap
	{
		event EventHandler<MapDataChangedEventArgs> MapDataChanged;

		int Width { get; }
		int Height { get; }

		void Set(int Width, int Height);
		EMapObject GetMapData(Point Point);
		EMapObject GetMapData(int X, int Y);
		void SetMapData(Point Point, EMapObject MapObject);
		void SetMapData(int X, int Y, EMapObject MapObject);
		void PrintToConsole();
	}
}
