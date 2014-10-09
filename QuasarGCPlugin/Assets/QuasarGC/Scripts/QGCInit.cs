using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using QGC;

public class QGCInit : MonoBehaviour
{
		public string BaseUrl;
		public string GameKey;
		public string LeaderboardKey;
		public bool DebugMode;

		public void Awake ()
		{
				DontDestroyOnLoad (gameObject);
		}
	

		public void Start ()
		{
				QGC.API.DebugMode = true;
				QGC.API.Init (BaseUrl, GameKey, LeaderboardKey);
				QGC.API.SilentLogin ();
		}
	
		void OnDestroy ()
		{
	
		}
}

