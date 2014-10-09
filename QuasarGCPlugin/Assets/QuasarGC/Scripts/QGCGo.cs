using UnityEngine;
using System.Collections;

namespace QGC
{
		public class QGCGo : MonoBehaviour
		{
	
				void Awake ()
				{
						DontDestroyOnLoad (gameObject);
				}
	
				public void RunCoroutine (IEnumerator routine)
				{
						StartCoroutine (routine);
				}
	
				public void OnApplicationQuit ()
				{

				}

				public void Log (string log)
				{
						Debug.Log (log);
				}

				public void LogWarning (string log)
				{
						Debug.LogWarning (log);
				}

				public void LogError (string log)
				{
						Debug.LogError (log);
				}
		}
}