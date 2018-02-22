using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdaptiveAgent3
{
	public partial class Form1 : Form
	{
		private static Graphics g;
		private static Bitmap img;
		private static Rectangle rect;
		private static Graphics buffer;
		private static Pen pen;
		private static Random rand = new Random();
		private static World world;
		private static Evolution evolution;

		static long tickCount;
		bool expanded = true;

		public Form1()
		{
			InitializeComponent();
			pen = new Pen(Color.FromName("ControlDark"), 1);
			buffer = Graphics.FromHwnd(panelView.Handle);
			img = new Bitmap(panelView.Width, panelView.Height, buffer);
			rect = new Rectangle(0, 0, panelView.Width, panelView.Height);
			g = Graphics.FromImage(img);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			world = new World(panelView.Width, panelView.Height);
			evolution = new Evolution(world);

			UpdateInfo();
			UpdateKBTree();
		}

		private void Draw()
		{
			g.Clear(Color.White);

			world.Draw(g);

			g.Flush();
			buffer.DrawImage(img, rect);
		}

		private void UpdateInfo()
		{
			tsslTickCount.Text = "Время: " + tickCount.ToString();
			tsslEyeContact.Text = "Встечь: " + world.agent.eyeContacts.ToString();
			tsslCollision.Text = "Столкновений: " + world.agent.collisions.ToString();
			tsslEyePerCol.Text = "ст./время = " + ((float)world.agent.collisions / (float)tickCount/*world.agent.eyeContacts*/).ToString() +
								";  ст./вс. = " + ((int)((float)world.agent.collisions / (float)world.agent.eyeContacts * 100)).ToString() + " %";
			lblSitCount.Text = "Образов: " + world.agent.brain.situations.Count.ToString();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			world.Update();
			Draw();

			++tickCount;

			UpdateInfo();

			if (cbUpdateTree.Checked)
				UpdateKBTree();
		}

		private void panelView_Paint(object sender, PaintEventArgs e)
		{
			Draw();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			world.Reset();
			Draw();
		}

		private void nudTick_ValueChanged(object sender, EventArgs e)
		{
			timer.Interval = (int)nudTick.Value;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			btnStop.Enabled = false;
			btnStart.Enabled = btnNextStep.Enabled = true;

			timer.Stop();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			btnStop.Enabled = true;
			btnStart.Enabled = btnNextStep.Enabled = false;

			timer.Start();
		}

		private void panelView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				world.agent.SetPosition(e.X, e.Y);
			}
			else if (e.Button == MouseButtons.Right)
			{
				world.walls.Add(new Wall(e.X, e.Y, 100));
			}
			Draw();
		}

		public void UpdateKBTree()
		{
			tvKB.Nodes.Clear();
			ICollection<string> ss = world.agent.brain.situations.Keys;
			TreeNode cur = null;
			foreach (string s in ss)
			{
				string txt = s + "  [" + world.agent.brain.situations[s].emo.ToString("+#0.###;-#0.###;0") + "]";
				if (world.agent.brain.situations[s].lockEmo)
					txt += " *";
				TreeNode root = tvKB.Nodes.Add(txt);
				if (s == world.agent.sensKey)
				{
					root.BackColor = Color.SkyBlue;
					cur = root;
				}
/*				if (world.agent.brain.situations[s] == world.agent.brain.prevSit)
				{
					root.BackColor = Color.Orange;
				}
*/				ICollection<Brain.EAction> aa = world.agent.brain.situations[s].forecasts.Keys;
				foreach (Brain.EAction a in aa)
				{
					string str = "";
					switch (a)
					{
						case Brain.EAction.moveForwar:
							str = "^F";
							break;
						case Brain.EAction.moveBack:
							str = "vB";
							break;
						case Brain.EAction.turnLeft:
							str = "<L";
							break;
						case Brain.EAction.turnRight:
							str = ">R";
							break;
					}
					TreeNode act = root.Nodes.Add(str);
					if (s == world.agent.sensKey && a == world.agent.newAct)
					{
						act.BackColor = Color.SkyBlue;
					}
					var ff = world.agent.brain.situations[s].forecasts[a];
					foreach (var f in ff)
					{
						string txt2 = f.Key + "  x" + f.Value.ToString() + "  [" + world.agent.brain.situations[f.Key].emo.ToString("+#0.###;-#0.###;0") + "]";
						if (world.agent.brain.situations[f.Key].lockEmo)
							txt2 += " *";
						var bs = act.Nodes.Add(txt2);
						if (s == world.agent.sensKey && a == world.agent.newAct && world.agent.brain.bestSitKey == f.Key)
						{
							bs.BackColor = Color.Cyan;
						}
					}
				}
			}
			if (expanded)
				tvKB.ExpandAll();
			if (cur != null)
			{
				tvKB.SelectedNode = cur;
				cur.Expand();
			}
		}

		private void btnUpdateTree_Click(object sender, EventArgs e)
		{
			UpdateKBTree();
		}

		private void btnExpCol_Click(object sender, EventArgs e)
		{
			if (expanded)
			{
				tvKB.CollapseAll();
			}
			else
			{
				tvKB.ExpandAll();
			}
			expanded = !expanded;
		}

		private void btnResetAgent_Click(object sender, EventArgs e)
		{
			tickCount = 0;

			world.agent = null;
			world.agent = new Agent(world, rand.Next(world.width - 50) + 25, rand.Next(world.height - 50) + 25, (float)rand.Next(360));
			Draw();

			UpdateInfo();
			UpdateKBTree();
		}

		private void btnPlus_Click(object sender, EventArgs e)
		{
			UseWaitCursor = true;

			for (int i = 0; i < 9999; ++i)
			{
				Application.DoEvents();
				world.Update();
			}
			tickCount += 9999;
			timer_Tick(null, null);

			UseWaitCursor = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			UseWaitCursor = true;

			for (int i = 0; i < 99999; ++i)
			{
				Application.DoEvents();
				world.Update();
				
			}
			tickCount += 99999;
			timer_Tick(null, null);

			UseWaitCursor = false;
		}

		private void btnClearMap_Click(object sender, EventArgs e)
		{
			world.walls.Clear();
			Draw();
		}

		private void tvKB_AfterExpand(object sender, TreeViewEventArgs e)
		{
			e.Node.ExpandAll();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			UseWaitCursor = true;

			for (int i = 0; i < 999999; ++i)
			{
				Application.DoEvents();
				world.Update();
			}
			tickCount += 999999;
			timer_Tick(null, null);

			UseWaitCursor = false;
		}

		private void btnEvoStart_Click(object sender, EventArgs e)
		{
			UseWaitCursor = true;

			evolution.Evolve();
			btnShowBests.PerformClick();

			UseWaitCursor = false;
		}

		private void btnShowBests_Click(object sender, EventArgs e)
		{
			g.Clear(Color.White);

			evolution.DrawBests(g);

			g.Flush();
			buffer.DrawImage(img, rect);
		}

		private void btnEvoReset_Click(object sender, EventArgs e)
		{
			evolution = new Evolution(world);
		}
	}
}
