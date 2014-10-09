using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class GetAllAchievementsEvent : QGCEvent
		{
		
				public GetAllAchievementsEvent (QGCAllAchievementsResponse allAchievements)
				{
						this.PlayerAchievements = allAchievements.objectContainer;
						this.ErrorInfo = allAchievements.ErrorInfo;
				}

				public GetAllAchievementsEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public List<QGCAchievement> PlayerAchievements{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
