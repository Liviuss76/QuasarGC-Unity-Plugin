using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class QGCAllAchievementsResponse
		{
				public QGCAllAchievementsResponse (List<QGCAchievement> PlayerAchievements, QGCErrorInfo ErrorInfo)
				{
						this.objectContainer = PlayerAchievements;
						this.ErrorInfo = ErrorInfo;
				}
				public List<QGCAchievement> objectContainer{ get; set; }
				public QGCErrorInfo ErrorInfo{ get; set; }
		}
}
