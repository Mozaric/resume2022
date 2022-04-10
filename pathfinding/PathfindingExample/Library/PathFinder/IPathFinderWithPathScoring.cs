using PathfindingExample.Library.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public interface IPathFinderWithPathScoring
	{
		event EventHandler<NodeListCountChanged> OpenNodeListItemAdded;
		event EventHandler<NodeListCountChanged> OpenNodeListItemRemoved;
		event EventHandler<NodeListCountChanged> CloseNodeListItemAdded;
		event EventHandler<NodeListCountChanged> CloseNodeListItemRemoved;

		IMap Map { get; }

		void Set(IMap Map);
		List<Point> FindPath(Point StartPoint, Point EndPoint);
	}
}
