using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class QGCAllScoresResponse
		{
				public QGCAllScoresResponse (List<QGCPlayerScore> PlayerScores, QGCErrorInfo ErrorInfo)
				{
						this.objectContainer = PlayerScores;
						this.ErrorInfo = ErrorInfo;
				}
				public List<QGCPlayerScore> objectContainer{ get; set; }
				public QGCErrorInfo ErrorInfo{ get; set; }
		}
}
