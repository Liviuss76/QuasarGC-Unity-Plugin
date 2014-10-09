using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class RegisterEvent : QGCEvent
		{
		
				public RegisterEvent (QGCPlayerResponse player)
				{
						this.Player = player.objectContainer;
						this.ErrorInfo = player.ErrorInfo;
				}

				public RegisterEvent (string error)
				{
						this.ErrorInfo = new QGCErrorInfo (error);
				}
		
				public QGCPlayer Player{ get; set; }
				public QGCErrorInfo ErrorInfo { get; set; }
		}
}
