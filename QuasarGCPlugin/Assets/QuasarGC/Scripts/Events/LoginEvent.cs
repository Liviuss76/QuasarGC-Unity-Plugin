using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class LoginEvent : QGCEvent
		{
		
				public LoginEvent (QGCPlayerResponse player)
				{
						this.Player = player.objectContainer;
						this.ErrorInfo = player.ErrorInfo;
				}

				public LoginEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public QGCPlayer Player{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
