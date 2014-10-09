using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class UpdateProfileEvent : QGCEvent
		{
		
				public UpdateProfileEvent (QGCPlayerResponse player)
				{
						this.Player = player.objectContainer;
						this.ErrorInfo = player.ErrorInfo;
				}

				public UpdateProfileEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public QGCPlayer Player{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
