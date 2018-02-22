using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AdaptiveAgent3
{
	class Wall: Circle
	{
		private static Random rand = new Random();
		SolidBrush brush;

		public Wall(int x, int y, int size): base (x, y, size/2)
		{
			brush = new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
		}

		public Wall(int x, int y, int size, Color color): base(x, y, size/2)
		{
			brush = new SolidBrush(color);
		}

		public void Draw(Graphics g)
		{
			g.FillEllipse(brush, x-r, y-r, r*2, r*2);
		}
	}
}
