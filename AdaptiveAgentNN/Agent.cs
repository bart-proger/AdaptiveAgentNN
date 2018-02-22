using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AdaptiveAgent3
{
	class Agent: Circle
	{
		public class Sensor: Circle
		{
			public bool feel;
			public double locDir, locDist;
			public Sensor(double direction, double distance, int radius): base(0, 0, radius)
			{
				feel = false;
				this.locDir = direction;
				this.locDist = distance;

				Update(0, 0, 0.0);
			}

			public void Update(int agentX, int agentY, double agentDir)
			{
				x = (int)(Math.Cos(agentDir + locDir) * locDist + agentX);
				y = (int)(Math.Sin(agentDir + locDir) * locDist + agentY);
				feel = false;
			}

		};

		static Random rand = new Random();

		public Brain brain;
		public string sensKey = "";
		//public Brain.Situation newSit;
		public Brain.EAction newAct;
		public World myWorld;

		public double dir;

		public Sensor[] sensors;  // 0 1 2 - eyes; 3 4 5 - front; 6 7 - back

		SolidBrush bc;

		private const double SPEED = 30;//16.0;
		private const int SIZE = 30;
		public const int SENS_COUNT = 8;

		public int eyeContacts;
		public int collisions;
		public int actions;
		public int forwardMoves;

		public Agent(World world, int x, int y, double dir): base(x, y, SIZE/2)
		{
			bc = new SolidBrush(Color.FromArgb(100, Color.Red));

			this.dir = dir;
			this.myWorld = world;

			sensors = new Sensor[SENS_COUNT];
/*
 			sensors[0] = new Sensor( Math.PI / 5.0, (double)r * 2.8 -2.0, 10);
 			sensors[1] = new Sensor(0,				(double)r * 2.8 -2.0, 10);
 			sensors[2] = new Sensor(-Math.PI / 5.0, (double)r * 2.8 - 2.0, 10);

			sensors[3] = new Sensor( Math.PI / 5.0, (double)r * 1.7 - 2.0, 8);
			sensors[4] = new Sensor(0,				(double)r * 1.7 - 2.0, 8);
			sensors[5] = new Sensor(-Math.PI / 5.0, (double)r * 1.7 - 2.0, 8);

			sensors[6] = new Sensor( Math.PI / 3.0, (double)r * 2.0 / 3.0 -3.0, r/2 +4);
			sensors[7] = new Sensor(0,				(double)r * 2.0 / 3.0 -3.0, r/2 +4);
			sensors[8] = new Sensor(-Math.PI / 3.0, (double)r * 2.0 / 3.0 -3.0, r/2 +4);

			sensors[9] = new Sensor(  Math.PI * 3.0 / 4.0, (double)r * 2.0 / 3.0 -3.0, r/2 +4);
			sensors[10] = new Sensor(-Math.PI * 3.0 / 4.0, (double)r * 2.0 / 3.0 -3.0, r/2 +4);
*/

			sensors[0] = new Sensor(Math.PI / 4.0,  (double)r * 2.5 - 2.0, 15);
			sensors[1] = new Sensor(0,				(double)r * 2.5 - 2.0, 15);
			sensors[2] = new Sensor(-Math.PI / 4.0, (double)r * 2.5 - 2.0, 15);

			sensors[3] = new Sensor(Math.PI / 3.0,  (double)r * 2.0 / 3.0 - 3.0, r / 2 + 4);
			sensors[4] = new Sensor(0,				(double)r * 2.0 / 3.0 - 3.0, r / 2 + 4);
			sensors[5] = new Sensor(-Math.PI / 3.0, (double)r * 2.0 / 3.0 - 3.0, r / 2 + 4);

			sensors[6] = new Sensor(Math.PI * 3.0 / 4.0,  (double)r * 2.0 / 3.0 - 3.0, r / 2 + 4);
			sensors[7] = new Sensor(-Math.PI * 3.0 / 4.0, (double)r * 2.0 / 3.0 - 3.0, r / 2 + 4);

			UpdateSensors();

			brain = new Brain();

			eyeContacts = 0;
			collisions = 0;
			actions = 0;
			forwardMoves = 0;
	}

		public void SetEyeSensors(double[] dir, double[] dist, int[] r)
		{
// 			for (int i = 0; i < 3; ++i)
// 				sensors[i] = new Sensor(dir[i], dist[i], r[i]);

			sensors[0] = new Sensor( dir[0], dist[0], r[0]);
			sensors[1] = new Sensor( 0,      dist[1], r[1]);
			sensors[2] = new Sensor(-dir[0], dist[0], r[0]);

			UpdateSensors();
		}

		public void Draw(Graphics g)
		{
			g.FillEllipse(Brushes.Blue, x-r, y-r, r*2, r*2);

			for (int i = 0; i < SENS_COUNT; ++i)
			{
				Sensor s = sensors[i];
				if (! s.feel)
					g.DrawEllipse(Pens.Gray, s.x - s.r, s.y - s.r, s.r * 2, s.r * 2);
				else if (i >= SENS_COUNT-5)
					g.FillEllipse(Brushes.Yellow, s.x - s.r, s.y - s.r, s.r * 2, s.r * 2);
				else
					g.FillEllipse(bc, s.x - s.r, s.y - s.r, s.r * 2, s.r * 2);
					
			}
		}

		public void Update()
		{
		//	MoveForward();
		}

		public void UpdateSensors()
		{
			sensKey = "";

			foreach (Sensor sens in sensors)
			{
				sens.Update(x, y, dir);
				sens.feel = sens.OutFrom(myWorld.width, myWorld.height);

				foreach (Wall w in myWorld.walls)
				{
					sens.feel = sens.feel || sens.CollidedTo(w);
				}
				if (sens.feel)
					sensKey += "1";
				else
					sensKey += "0";
			}

			if (sensKey.IndexOf('1', SENS_COUNT-5/*, 3*/) >= SENS_COUNT-5) //-? только лобовое столкновение
				collisions++;
			/*else */if (sensKey.IndexOf('1', 0, 3) >= 0)
				eyeContacts++;
		}

		public void SetPosition(int x, int y)
		{
			this.x = x;
			this.y = y;
			UpdateSensors();
		}

// Actions		
		public void MoveForward()
		{
			x += (int)(Math.Cos(dir) * SPEED);
			y += (int)(Math.Sin(dir) * SPEED);
			forwardMoves++;
			actions++;
		}

		public void MoveBack() 
		{
 			x -= (int)(Math.Cos(dir) * SPEED);  /// +/-
 			y -= (int)(Math.Sin(dir) * SPEED);  /// 
 			actions++;
		}

		public void TurnLeft()
		{
			dir -= Math.PI / 4.0;// + rand.NextDouble() * 0.2 - 0.1;

			x += (int)(Math.Cos(dir) * SPEED);
			y += (int)(Math.Sin(dir) * SPEED);

			actions++;
		}

		public void TurnRight()
		{
			dir += Math.PI / 4.0;// + rand.NextDouble() * 0.2 - 0.1;

			x += (int)(Math.Cos(dir) * SPEED);
			y += (int)(Math.Sin(dir) * SPEED);

			actions++;
		}
	}
}
