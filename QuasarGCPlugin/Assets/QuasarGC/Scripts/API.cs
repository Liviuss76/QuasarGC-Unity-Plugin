using UnityEngine;
using System.Collections;
using System;

namespace QGC
{
		public class API
		{ 
				public static string BaseUrl { get; set; }
				public static string GameKey { get; set; }
				public static string LeaderboardKey { get; set; }
				public static bool DebugMode = false;
				
				public static QGCPlayer Player { get; set; }
				private static QGCGo _controller;
				private static QGCImpl command;

				public static QGCGo QGC_controller {
						get { return _controller;}
				}
					
				private static QGCImpl Send { 
						get { return command;}
				}

				
				public static void Init (string BaseUrl, string GameKey, string LeaderboardKey)
				{
						API.BaseUrl = BaseUrl;
						API.GameKey = GameKey;
						API.LeaderboardKey = LeaderboardKey;	
						
						if (command == null)
								command = new QGCImpl ();
						if (_controller == null) {
								GameObject qgc = GameObject.Find ("QGCInit");
								_controller = qgc.AddComponent<QGCGo> ();
						}
				}

				public static void RunCoroutine (IEnumerator routine)
				{
						RunCoroutine (routine, () => true);
				}
	
				public static void RunCoroutine (IEnumerator routine, Func<bool> done)
				{
						QGC_controller.RunCoroutine (routine);
						
				}
	
				public static void Log (object msg)
				{
						if (API.DebugMode)
								QGC_controller.Log ("QGC:" + msg);
				}
	
				public static void LogWarning (object msg)
				{
						if (API.DebugMode)
								QGC_controller.LogWarning ("QGC Warning:" + msg);
				}
	
				public static void LogError (object msg)
				{
						if (API.DebugMode)
								QGC_controller.LogWarning ("QGC Error:" + msg);
				}

				#region Public exposed methods
				public static void Login (string username, string password)
				{
						Send.Login (username, password);
				}

				public static void SilentLogin ()
				{
						Send.SilentLogin ();
				}

				public static bool IsLoggedIn ()
				{
						return Player != null;
				}

				public static void Register (string username, string password, string displayname)
				{
						Send.Register (username, password, displayname);
				}

				public static void Register (string username, string password, string displayname, string firstname, string lastname, string email, string birthdate, string sex, string picture)
				{
						Send.Register (username, password, displayname, firstname, lastname, email, birthdate, sex, picture);
				}

				public static void Register (QGCPlayerSend pls)
				{
						Send.Register (pls);
				}

				public static bool IsRegistered ()
				{
						return PlayerPrefs.HasKey ("_authToken");
				}

				public static void UpdateProfile (string password, string displayname, string firstname, string lastname, string email, string birthdate, string sex, string picture)
				{
						Send.UpdateProfile (password, displayname, firstname, lastname, email, birthdate, sex, picture);
				}
		
				public static void UpdateProfile (QGCPlayerSend pls)
				{
						Send.UpdateProfile (pls);
				}

				public static void SubmitScore (int score)
				{
						Send.SubmitScore (score);
				}

				public static void SubmitScore (String leaderBoardKey, int score)
				{
						API.LeaderboardKey = leaderBoardKey;
						Send.SubmitScore (score);
				}

				public static void GetAllScores (String leaderBoardKey)
				{
						Send.GetAllScores (leaderBoardKey);
				}

				public static void GetAllScores (int page, int size)
				{
						Send.GetAllScores (page, size);
				}

				public static void GetAllScores (String leaderBoardKey, int page, int size)
				{
						Send.GetAllScores (leaderBoardKey, page, size);
				}

				public static void GetAllScores ()
				{
						Send.GetAllScores ();
				}

				public static void GetPlayerScore (String leaderBoardKey)
				{
						Send.GetPlayerScore (leaderBoardKey);
				}

				public static void GetPlayerScore ()
				{
						Send.GetPlayerScore ();
				}

				public static void GetAllAchievements ()
				{
						Send.GetAllAchievements ();
				}

				public static void GetAchievement (String achievementCode)
				{
						Send.GetAchievement (achievementCode);
				}

				public static void UnlockAchievement (String achievementCode)
				{
						Send.UnlockAchievement (achievementCode);
				}

				public static void SubmitAchievement (String achievementCode, double unlockPoints)
				{
						Send.SubmitAchievement (achievementCode, unlockPoints);
				}
				#endregion
		}
}
