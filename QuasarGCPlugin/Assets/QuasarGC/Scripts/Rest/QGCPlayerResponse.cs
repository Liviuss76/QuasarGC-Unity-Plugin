namespace QGC
{
		public class QGCPlayerResponse
		{
				public QGCPlayerResponse (QGCPlayer Player, QGCErrorInfo ErrorInfo)
				{
						this.objectContainer = Player;
						this.ErrorInfo = ErrorInfo;
				}
				public QGCPlayer objectContainer{ get; set; }
				public QGCErrorInfo ErrorInfo{ get; set; }
		}
}