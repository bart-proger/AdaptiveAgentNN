using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveAgent3
{
	class Brain
	{
		static Random rand = new Random();
		public enum EAction { moveForwar = 0, moveBack = 1, turnLeft = 2, turnRight = 3, unknownAction = -1 };

		public class Situation
		{
			public double emo;
			public bool lockEmo;
			public EAction favoritAction;
			public Dictionary<EAction, Dictionary<string, int>> forecasts;

			public Situation(double emo)
			{
				this.emo = emo;
				lockEmo = false;
				favoritAction = EAction.moveForwar;
				forecasts = new Dictionary<EAction, Dictionary<string, int>>();
			}
		};

		public const double MAX_EMO = 5;
		public const int RAND_PERCENT = 3;

		public Dictionary<string, Situation> situations;
		public Situation prevSit;
		public EAction prevAct;
		public string bestSitKey;

		public Brain()
		{
			situations = new Dictionary<string, Situation>();

			prevSit = new Situation(+MAX_EMO);
			prevAct = EAction.moveForwar;
			string s = "";
			for (int i = 0; i < Agent.SENS_COUNT; ++i)
				s += "0";
			situations.Add(s, prevSit);
			var dic = new Dictionary<string,int>();
			dic.Add(s, 1);
			prevSit.forecasts.Add(EAction.moveForwar, dic);
			prevSit.lockEmo = true;
		}

		public EAction GetNextAction(string newSitKey)
		{
			Situation newSit;
			EAction newAct;

			if (situations.ContainsKey(newSitKey))
			{
				newSit = situations[newSitKey];

				double shiftEmo = (newSit.emo + prevSit.emo) / 2;

				if (!prevSit.lockEmo || 
						(prevSit.lockEmo && Math.Sign(shiftEmo) == Math.Sign(prevSit.emo) && Math.Abs(shiftEmo) > Math.Abs(prevSit.emo)))
				{
					prevSit.emo = Math.Truncate(shiftEmo);

					//if (!prevSit.Equals(newSit))
					//	{
					//			if (Math.Abs(Math.Abs(prevSit.emo) - Math.Abs(newSit.emo)) >= (MAX_EMO / 5f))
		//			if (prevSit.emo == +MAX_EMO)
		//				prevSit.emo = newSit.emo / 2.0f;
					//					else if (Math.Abs(prevSit.emo - newSit.emo) >= (MAX_EMO / 4.0f))
			//*		prevSit.emo = (newSit.emo + prevSit.emo) / 2.0f;
					//			prevSit.emo += (float)Math.Sign(prevSit.emo) * (MAX_EMO - Math.Abs(prevSit.emo)) * 0.01f; //  + 1% остатка до МАХ_ЕМО
					//			}
					// +0.01f;
//					if (prevSit.Equals(newSit))
//						prevSit.emo += Math.Sign(prevSit.emo) * 0.01f * MAX_EMO / prevSit.emo;
				}
			}
			else
			{
				newSit = new Situation(Math.Truncate(prevSit.emo / 2));//+MAX_EMO); 

				if (/*!newSit.lockEmo && */newSitKey.IndexOf('1', Agent.SENS_COUNT - 5) >= Agent.SENS_COUNT - 5)	// сталкиваться больно
				{
					double collisionEmo = -MAX_EMO / 5 * newSitKey.Substring(Agent.SENS_COUNT - 5).ToCharArray().Count(ch => ch == '1');
					//+if (newSit.emo > emo)
						newSit.emo = Math.Truncate(newSit.emo + collisionEmo);
//					if (newSit.emo < -MAX_EMO)
//						newSit.emo = -MAX_EMO;
					//+newSit.lockEmo = true;
				}

			}
				//			prevSit.emo += (float)rand.NextDouble() * 0.002f - 0.001f;

			//+if (/*!newSit.lockEmo && */newSitKey.IndexOf('1', 6) >= 6)	// сталкиваться больно
			//+{
			//+    double emo = -MAX_EMO / 5 * newSitKey.Substring(6).ToCharArray().Count(ch => ch == '1');
			//+    if (newSit.emo > emo)
			//+        newSit.emo = emo;
			//+    if (newSit.emo < -MAX_EMO)
			//+        newSit.emo = -MAX_EMO;
			//+    newSit.lockEmo = true;
			//+}


/*			if (newSitKey.IndexOf('1') < 0 && newSit.emo < +MAX_EMO)
			{
				newSit.emo = +MAX_EMO;
				newSit.lockEmo = true;
			}
*/
			
//---
			if (prevSit.forecasts.ContainsKey(prevAct))
			{
				if (prevSit.forecasts[prevAct].ContainsKey(newSitKey))  ///
				{
					Dictionary<string, int> counts = prevSit.forecasts[prevAct];
//+-
					foreach (var c in counts)
					{
						if (c.Value >= counts[newSitKey] && c.Key != newSitKey)
 						{
  							counts[newSitKey]++;
							break;
						}
  					}
 				}
				else
				{
					prevSit.forecasts[prevAct].Add(newSitKey, 1);
				}
			}
			else  // действия в прогнозе нет
			{
				Dictionary<string, int> fd = new Dictionary<string, int>();
				fd.Add(newSitKey, 1);
				prevSit.forecasts.Add(prevAct, fd);
			}

//---
/*
			if (newSitKey.IndexOf("1") < 0)	// если нет сигналов идти вперед
			{
				prevAct = newAct = EAction.moveForwar;
				prevSit = newSit = situations[newSitKey];

				return newAct;
			}
*/
			if (situations.ContainsKey(newSitKey))  // уже встречалась
			{
				ICollection<EAction> acts = newSit.forecasts.Keys;

				bestSitKey = newSit.forecasts.First().Value.First().Key;
				double bestEmo = -MAX_EMO;
				EAction bestAction = newSit.forecasts.First().Key;
//				int bestCount;

//				if (rand.Next(100) < RAND_PERCENT && newSit.forecasts.Count() < 4)
//					newAct = (EAction)rand.Next(4);
//				else
//				{
					foreach (EAction a in acts)
					{
						Dictionary<string, int> f = newSit.forecasts[a];
						
						var maxCount = f.Max(s => s.Value);
						var favList = f.Where(s => s.Value.Equals(maxCount)).Select(s => s.Key).ToList();

						double favEmo = -MAX_EMO;
						string favSitKey = f.First().Key;

						foreach (string fs in favList)
						{
							if (situations[fs].emo > favEmo)
							{
								favSitKey = fs;
								favEmo = situations[fs].emo;
							}
						}
						
						if (bestEmo < favEmo || (bestEmo == favEmo/* && rand.Next(100) < 50*/))//rand.Next(100) < RAND_PERCENT)
						{
							bestEmo = favEmo;
							bestAction = a;
							bestSitKey = favSitKey;
						}
					}
					if (bestEmo <= newSit.emo || (newSit.forecasts.Count() < 4 && rand.Next(100) < 50/*RAND_PERCENT*/))
					{
						while ((newAct = (EAction)rand.Next(4)) == bestAction)
						{
						}
						bestAction = newAct;
					}
					else
						newAct = bestAction;
//				}
				
				
			}
			else  // нет, это новая ситуация
			{
				situations.Add(newSitKey, newSit);
				//var nsit = NearSituation(newSitKey);

				newAct = (EAction)rand.Next(4);
//				if (newAct == EAction.moveBack)
//					newAct = EAction.moveForwar;
			}

//			if (prevSit != null)
//			{
			
//			}

			prevAct = newAct;
			prevSit = newSit;

			return newAct; 
		}

		public Situation NearSituation(string sitKey)
		{
			Situation near = situations[sitKey];
			int max = 0;
			foreach (string s in situations.Keys)
			{
				int c = 0;
				for (int i = 0; i < 8; ++i)
				{
					if (s[i] != sitKey[i])
						c++;
				}
				if (c > max)
				{
					max = c;
					near = situations[s];
				}
			}
			return near;
		}
	}
}
