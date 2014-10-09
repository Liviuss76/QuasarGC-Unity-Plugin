namespace QGC
{
		public class QGCPlayerScoreResponse
		{
				public QGCPlayerScoreResponse (QGCPlayerScore PlayerScore, QGCErrorInfo ErrorInfo)
				{
						this.objectContainer = PlayerScore;
						this.ErrorInfo = ErrorInfo;
				}
				public QGCPlayerScore objectContainer{ get; set; }
				public QGCErrorInfo ErrorInfo{ get; set; }
		}
}