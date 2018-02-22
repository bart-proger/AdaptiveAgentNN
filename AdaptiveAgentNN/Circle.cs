using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveAgent3
{
	class Circle
	{
		public int x, y, r;

		public Circle(int X, int Y, int Radius)
		{
			x = X;
			y = Y;
			r = Radius;
		}

		public static bool Collided(Circle c1, Circle c2)
		{
			int x = c1.x - c2.x;
			int y = c1.y - c2.y;
			return Math.Sqrt(x * x + y * y) <= c1.r + c2.r;
		}

		public bool CollidedTo(Circle c)
		{
			return Collided(this, c);
		}

		public bool OutFrom(int width, int height)
		{
			return (x - r < 0) || (x + r > width) || (y - r < 0) || (y + r > height);
		}

	}
}
