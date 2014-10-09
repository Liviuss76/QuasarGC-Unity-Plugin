namespace QGC
{
		public class QGCAchievementProgressResponse
		{
				public QGCAchievementProgressResponse (QGCAchievementProgress PlayerProgress, QGCErrorInfo ErrorInfo)
				{
						this.objectContainer = PlayerProgress;
						this.ErrorInfo = ErrorInfo;
				}
				public QGCAchievementProgress objectContainer{ get; set; }
				public QGCErrorInfo ErrorInfo{ get; set; }
		}
}