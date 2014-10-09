using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class AchievementUnlockedEvent : QGCEvent
		{
		
				public AchievementUnlockedEvent (QGCAchievementResponse playerAchievement)
				{
						this.PlayerAchievement = playerAchievement.objectContainer;
						this.ErrorInfo = playerAchievement.ErrorInfo;
				}

				public AchievementUnlockedEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public QGCAchievement PlayerAchievement{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
