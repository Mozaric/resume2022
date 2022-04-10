using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingExample.Library.PathFinder
{
	public enum MoveDirection
	{
		None = -1,
		Right = 0,
		RightTop = 1,
		Top = 2,
		LeftTop = 3,
		Left = 4,
		LeftBottom = 5,
		Bottom = 6,
		RightBottom = 7
	}
}
