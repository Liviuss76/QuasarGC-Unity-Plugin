using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class GetAllScoresEvent : QGCEvent
		{
		
				public GetAllScoresEvent (QGCAllScoresResponse allScores)
				{
						this.PlayerScores = allScores.objectContainer;
						this.ErrorInfo = allScores.ErrorInfo;
				}
				public GetAllScoresEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public List<QGCPlayerScore> PlayerScores{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
