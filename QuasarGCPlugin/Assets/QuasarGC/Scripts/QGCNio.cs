using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using Newtonsoft.Json;

namespace QGC
{
		public class QGCNio
		{	
				public static void CreateSubmitWWW (string url, string json, string auth, CategoryType catType)
				{
						WWW www = null;
						byte[] data = null;
			
						if (!string.IsNullOrEmpty (json)) {
								data = Encoding.UTF8.GetBytes (json);
						}
			
						Dictionary<string, string> headers = new Dictionary<string, string> ();
						headers.Add ("Content-Type", "application/json");
						headers.Add ("User-Agent", "QGC 1.0");
						headers.Add ("Connection", "close");
						headers.Add ("Authorization", "Basic " + auth);
			
						www = new WWW (url, data, headers);
			
						API.RunCoroutine (SendWWW (www, catType, json));
				}

				public static void CreateSubmitWWW (string url, string json, CategoryType catType)
				{
						WWW www = null;
						byte[] data = null;

						if (!string.IsNullOrEmpty (json)) {
								data = Encoding.UTF8.GetBytes (json);
						}
		
						Dictionary<string, string> headers = new Dictionary<string, string> ();
						headers.Add ("Content-Type", "application/json");
						headers.Add ("User-Agent", "QGC 1.0");
						headers.Add ("Connection", "close");
		
						www = new WWW (url, data, headers);

						API.RunCoroutine (SendWWW (www, catType, json));
						
				}
	
				public static IEnumerator SendWWW (WWW www, CategoryType catType, string json)
				{
						www.threadPriority = ThreadPriority.Low;
						yield return www;
						processResponse (www, catType, json);
				}
				
		#region Process answers				
				public static void processResponse (WWW www, CategoryType catType, string json)
				{
						if (API.DebugMode && string.IsNullOrEmpty (www.error)) {
								API.Log ("URL=> " + www.url);
								if (!string.IsNullOrEmpty (json))
										API.Log ("Submit=> " + json);
								API.Log ("Answer=> " + www.text);
				
						}
			
						if (!string.IsNullOrEmpty (www.error)) {
								switch (catType) {
								case CategoryType.QGC_GetAllScores: 
										QGCEvents.instance.Raise (new GetAllScoresEvent (new QGCAllScoresResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_GetPlayerScore:
										QGCEvents.instance.Raise (new GetPlayerScoreEvent (new QGCPlayerScoreResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_Login:
										QGCEvents.instance.Raise (new LoginEvent (new QGCPlayerResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_Register:
										QGCEvents.instance.Raise (new LoginEvent (new QGCPlayerResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_UpdateProfile:
										QGCEvents.instance.Raise (new UpdateProfileEvent (new QGCPlayerResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_SubmitScore:
										QGCEvents.instance.Raise (new GetPlayerScoreEvent (new QGCPlayerScoreResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_GetAllAchievements:
										QGCEvents.instance.Raise (new GetAllAchievementsEvent (new QGCAllAchievementsResponse (null, new QGCErrorInfo (www.error))));
										break;
								case CategoryType.QGC_GetAchievemnt:
										QGCEvents.instance.Raise (new GetPlayerAchievementEvent (new QGCAchievementResponse (null, new QGCErrorInfo (www.error))));
										break;
								default : 
										API.LogError (www.error);
										break;
								}
						} else {
								switch (catType) {
								case CategoryType.QGC_GetAllScores:
										QGCAllScoresResponse allScores = JsonConvert.DeserializeObject<QGCAllScoresResponse> (www.text);
										QGCEvents.instance.Raise (new GetAllScoresEvent (allScores));
										break;
								case CategoryType.QGC_GetPlayerScore:
										QGCPlayerScoreResponse playerScore = JsonConvert.DeserializeObject<QGCPlayerScoreResponse> (www.text);
										QGCEvents.instance.Raise (new GetPlayerScoreEvent (playerScore));
										break;
								case CategoryType.QGC_Login:
										QGCPlayerResponse playerResp = JsonConvert.DeserializeObject<QGCPlayerResponse> (www.text);
										API.Player = playerResp.objectContainer;
										QGCEvents.instance.Raise (new LoginEvent (playerResp));
										break;
								case CategoryType.QGC_Register:
										QGCPlayerResponse regResp = JsonConvert.DeserializeObject<QGCPlayerResponse> (www.text);
										API.Player = regResp.objectContainer;
										QGCEvents.instance.Raise (new RegisterEvent (regResp));
										break;
								case CategoryType.QGC_UpdateProfile:
										QGCPlayerResponse updateProfileResp = JsonConvert.DeserializeObject<QGCPlayerResponse> (www.text);
										API.Player = updateProfileResp.objectContainer;
										QGCEvents.instance.Raise (new UpdateProfileEvent (updateProfileResp));
										break;
								case CategoryType.QGC_SubmitScore:
										QGCPlayerScoreResponse playerScoreResp = JsonConvert.DeserializeObject<QGCPlayerScoreResponse> (www.text);
										QGCEvents.instance.Raise (new GetPlayerScoreEvent (playerScoreResp));
										break;
								case CategoryType.QGC_GetAllAchievements:
										QGCAllAchievementsResponse allAchievements = JsonConvert.DeserializeObject<QGCAllAchievementsResponse> (www.text);
										QGCEvents.instance.Raise (new GetAllAchievementsEvent (allAchievements));
										break;
								case CategoryType.QGC_GetAchievemnt:
										QGCAchievementResponse achievement = JsonConvert.DeserializeObject<QGCAchievementResponse> (www.text);
										QGCEvents.instance.Raise (new GetPlayerAchievementEvent (achievement));
										break;
								case CategoryType.QGC_UnlockAchievement:
										QGCAchievementResponse unlockAchievement = JsonConvert.DeserializeObject<QGCAchievementResponse> (www.text);
										QGCEvents.instance.Raise (new AchievementUnlockedEvent (unlockAchievement));
										break;
								case CategoryType.QGC_SubmitAchievement:
										QGCAchievementProgressResponse submitAchievement = JsonConvert.DeserializeObject<QGCAchievementProgressResponse> (www.text);
										QGCEvents.instance.Raise (new AchievementSubmitEvent (submitAchievement));
										break;
								default : 
										API.LogError ("Unknown answer=> " + www.text);
										break;
								}
				
						}
				}
		#endregion
				
		}
}