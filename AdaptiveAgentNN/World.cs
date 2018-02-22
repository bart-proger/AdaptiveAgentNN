using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AdaptiveAgent3
{
	class World
	{
		Random rand;
		public Agent agent;
		public List<Wall> walls;

		public int width, height;

		public World(int W, int H)
		{
			rand = new Random();
			width = W;
			height = H;

			walls = new List<Wall>();
			agent = new Agent(this, rand.Next(width - 50) + 25, rand.Next(height - 50) + 25, (float)rand.Next(360));

			Reset();
		}

		public void Update()
		{
			switch (agent.newAct)
			{
				case Brain.EAction.moveForwar:
					agent.MoveForward();
					break;
				case Brain.EAction.moveBack:
					agent.MoveBack();
					break;
				case Brain.EAction.turnLeft:
					agent.TurnLeft();
					break;
				case Brain.EAction.turnRight:
					agent.TurnRight();
					break;
			}

			int d = 0;
			int s = 0;
			Point shift = new Point(0, 0);

			foreach (Wall w in walls)
			{
				d = Distance(w.x, w.y, agent.x, agent.y);
				s = w.r + agent.r - d;

				if (s > 0)
					shift.Offset((int)((double)(agent.x - w.x) / (double)d * (double)s), (int)((double)(agent.y - w.y) / (double)d * (double)s));
			}

			if (agent.x - agent.r < 0)
				shift.Offset(agent.r - agent.x, 0);
			else if (agent.x + agent.r > width)
				shift.Offset(width - (agent.x + agent.r), 0);

			if (agent.y - agent.r < 0)
				shift.Offset(0, agent.r - agent.y);
			else if (agent.y + agent.r > height)
				shift.Offset(0, height - (agent.y + agent.r));

			agent.x += shift.X;
			agent.y += shift.Y;

			agent.UpdateSensors();

			agent.newAct = agent.brain.GetNextAction(agent.sensKey);
		}
		
		public void Draw(Graphics g)
		{
			foreach (Wall w in walls)
			{
				w.Draw(g);
			}
			agent.Draw(g);
		}

		public void Reset()
		{
			walls.Clear();

			int count = rand.Next(20, 30);
			for (int i = 0; i < count; i++)
			{
				walls.Add(new Wall(rand.Next(width), rand.Next(height), rand.Next(30, 50)));
			}
		}

		private int Distance(int x1, int y1, int x2, int y2)
		{
			int x = x1 - x2;
			int y = y1 - y2;
			return (int)Math.Sqrt(x*x + y*y);
		}
	}
}
