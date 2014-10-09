using UnityEngine;
using System.Collections;

namespace QGC
{
		public class QGCErrorInfo
		{
				public QGCErrorInfo (string ErrorMessage)
				{
						this.ErrorMessage = ErrorMessage;
				}

				public string ErrorMessage { get; set; }

		}
}
