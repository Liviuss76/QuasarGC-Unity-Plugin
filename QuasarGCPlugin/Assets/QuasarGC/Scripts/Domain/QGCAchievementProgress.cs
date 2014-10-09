using UnityEngine;
using System.Collections;

namespace QGC
{
		public class QGCAchievementProgress
		{
				public string AchievementCode { get; set; }
				public double AchievementProgress{ get; set; }
				public QGCAchievement Achievement{ get; set; }

				public override string ToString ()
				{
						if (Achievement == null) {
								return "Code:" + AchievementCode + " Progress:" + AchievementProgress;
						} else {
								return "Unlocked:" + Achievement;
						}
				}
		}
}
