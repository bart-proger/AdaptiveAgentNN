using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaptiveAgent3
{
	class Evolution
	{
		static Random rand = new Random();

		class Gene
		{
			public float[] fitness = new float[3];
			public int generation = 0;

			public double[] dir = new double[3];
			public double[] dist = new double[3];
			public int[] r = new int[3];
//			public float speed = 0;
//			public float turnSpeed = 0;

			public Gene()
			{
				for (int i = 0; i < 3; ++i)
				{
					dir[i] = rand.NextDouble() * 2.0 * Math.PI;
					dist[i] = rand.NextDouble() * 40;
					r[i] = rand.Next(20) + 1;
				}
			}
		}

		World world;
		List<Gene> population;
		List<Gene> bests;
		int generationCount = 0;

		int populationSize = 100;
		float bestsPercent = 0.10f;
		float mutationPercent = 0.05f;

		public Evolution(World world)
		{
			this.world = world;
			population = new List<Gene>();
			bests = new List<Gene>();

			while (population.Count < populationSize)
			{
				population.Add(new Gene());
			}
		}

		public void Evolve()
		{
			for (int i = 0; i < population.Count; ++i)
			{
				world.agent = null;
				world.agent = new Agent(world, rand.Next(world.width - 50) + 25, rand.Next(world.height - 50) + 25, (float)rand.Next(360));
				world.agent.SetEyeSensors(population[i].dir, population[i].dist, population[i].r);

				for (int n = 0; n < 10000; ++n)
				{
					Application.DoEvents();

					world.Update();
				}

				population[i].fitness[0] = (float)world.agent.collisions / (float)world.agent.eyeContacts;
				population[i].fitness[1] = (float)(population[i].dist[0] + population[i].dist[1]) / 2f;
				population[i].fitness[2] = world.agent.eyeContacts;//(float)(population[i].r[0] + population[i].r[1]) / 2f;
			}

			population.Sort(delegate(Gene g1, Gene g2)
							{
								int c = g1.fitness[0].CompareTo(g2.fitness[0]);
								if (Math.Abs(g1.fitness[0] - g2.fitness[0]) < 0.01)
								{
									//int d = g1.fitness[1].CompareTo(g2.fitness[1]);
									//if (d == 0)
									//{
										int r = g1.fitness[2].CompareTo(g2.fitness[2]);
										return r;
									//}
									//return d;
								}
								return c;
							});

			int bestsCount = (int)(population.Count * bestsPercent);
			bests.Clear();
			bests.AddRange(population.GetRange(0, bestsCount));

			population.Clear();
			population.AddRange(bests);

			++generationCount;

			int a = -1;
			int b = 0;
			while (population.Count < populationSize)
			{
				++a;
				a %= bestsCount;
				b = a;
				while (b == a)
					b = rand.Next(bestsCount);

				population.Add(Mutation(Crossover(bests[a], bests[b])));
				population.Last().generation = generationCount;
			}

			world.agent = null;
			world.agent = new Agent(world, rand.Next(world.width - 50) + 25, rand.Next(world.height - 50) + 25, (float)rand.Next(360));
			world.agent.SetEyeSensors(bests.First().dir, bests.First().dist, bests.First().r);
		}

		private Gene Crossover(Gene gene1, Gene gene2)
		{
			Gene child = new Gene();
			Gene parent = gene1;
			int cut = rand.Next(8-2)+1;
			int n = 0;
			for (int i = 0; i < 3; ++i)
			{
				if (n == cut)
					parent = gene2;
				n++;

				child.dir[i] = parent.dir[i];
			}
			for (int i = 0; i < 3; ++i)
			{
				if (n == cut)
					parent = gene2;
				n++;

				child.dist[i] = parent.dist[i];
			}
			for (int i = 0; i < 3; ++i)
			{
				if (n == cut)
					parent = gene2;
				n++;

				child.r[i] = parent.r[i];
			}

			return child;
		}

		Gene Mutation(Gene gene)
		{
			Gene rg = new Gene();

			for (int i = 0; i < 3; ++i)
			{
				if (rand.NextDouble() < mutationPercent)
					gene.dir[i] = rg.dir[i];

				if (rand.NextDouble() < mutationPercent)
					gene.dist[i] = rg.dist[i];

				if (rand.NextDouble() < mutationPercent)
					gene.r[i] = rg.r[i];
			}
			return gene;
		}

		public void DrawBests(Graphics g)
		{
			Font font = new Font("Arial", 10);
			Agent agent;
			int x = -30, y = 50;
			foreach (var b in bests)
			{
				x += 150;
				if (x > 550)
				{
					x = 70;
					y += 150;
				}

				agent = null;
				agent = new Agent(world, x, y, Math.PI / 2.0);
				agent.SetEyeSensors(b.dir, b.dist, b.r);
				agent.Draw(g);
				g.DrawString(b.fitness[0].ToString("0.#######"), font, Brushes.Black, x-30, y+60);
				g.DrawString(b.generation.ToString(), font, Brushes.Black, x-50, y - 40);
			}
		}
	}
}
