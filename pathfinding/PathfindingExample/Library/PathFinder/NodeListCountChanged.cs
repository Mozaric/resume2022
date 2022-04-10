using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public class NodeListCountChanged : EventArgs
	{
		public Node Node { get; private set; }

		public NodeListCountChanged(Node Node)
		{
			this.Node = Node;
		}
	}
}
