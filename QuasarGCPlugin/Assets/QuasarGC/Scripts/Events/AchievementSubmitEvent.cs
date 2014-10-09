using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class AchievementSubmitEvent : QGCEvent
		{
		
				public AchievementSubmitEvent (QGCAchievementProgressResponse achievementProgress)
				{
						this.PlayerAchievementProgress = achievementProgress.objectContainer;
						this.ErrorInfo = achievementProgress.ErrorInfo;
				}

				public AchievementSubmitEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public QGCAchievementProgress PlayerAchievementProgress{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
