using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class GetPlayerScoreEvent : QGCEvent
		{
		
				public GetPlayerScoreEvent (QGCPlayerScoreResponse playerScore)
				{
						this.PlayerScore = playerScore.objectContainer;
						this.ErrorInfo = playerScore.ErrorInfo;
				}

				public GetPlayerScoreEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public QGCPlayerScore PlayerScore{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
