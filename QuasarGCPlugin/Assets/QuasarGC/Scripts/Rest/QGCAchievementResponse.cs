namespace QGC
{
		public class QGCAchievementResponse
		{
				public QGCAchievementResponse (QGCAchievement PlayerAchievement, QGCErrorInfo ErrorInfo)
				{
						this.objectContainer = PlayerAchievement;
						this.ErrorInfo = ErrorInfo;
				}
				public QGCAchievement objectContainer{ get; set; }
				public QGCErrorInfo ErrorInfo{ get; set; }
		}
}