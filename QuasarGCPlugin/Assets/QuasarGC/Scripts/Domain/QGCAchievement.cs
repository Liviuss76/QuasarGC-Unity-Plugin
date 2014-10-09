using UnityEngine;
using System.Collections;

namespace QGC
{
		public class QGCAchievement
		{
				public string AchievementName { get; set; }
				public string AchievementDesc { get; set; }
				public string AchievementImage { get; set; }
				public string AchievementCode { get; set; }
				public double AchievementUnlockPoints{ get; set; }
				public long AchievementBonusPoints{ get; set; }
				public double AchievementProgress{ get; set; }
				public bool AchievementUnlocked{ get; set; }
				public bool AchievementRepeatable{ get; set; }

				public override string ToString ()
				{
						return " Code:" + AchievementCode + " Name:" + AchievementName + " Desc:" + AchievementDesc + " Image:" + AchievementImage.Length + "b " + " Progress:" + AchievementProgress + " Unlock Points:" + AchievementUnlockPoints + " Bonus Points:" + AchievementBonusPoints + " Unlocked:" + AchievementUnlocked + " Repeatable:" + AchievementRepeatable;
				}
		}
}
