using UnityEngine;
using System;
using System.Text;
using System.Collections;
using Newtonsoft.Json;

namespace QGC
{
		public class QGCImpl
		{
				private string _leaderboardKey;
				private string _gameKey;
				private string _authToken;
				private static string _baseURL;

				public QGCImpl ()
				{
						_leaderboardKey = API.LeaderboardKey;
						_gameKey = API.GameKey;
						_baseURL = API.BaseUrl;
						QGCEvents.instance.AddListener<LoginEvent> (OnPlayerLogin);
						QGCEvents.instance.AddListener<RegisterEvent> (OnPlayerRegistered);
			
				}
		#region Login
				public void Login (string username, string password)
				{
						if (!ApiReady ())
								return;
						if (string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password)) {
								API.LogWarning ("Username/Pass must not be empty");
								return;
						}
						string url = _baseURL + "/player";
						_authToken = encodeAuth (username + ":" + password);
						QGCNio.CreateSubmitWWW (url, null, _authToken, CategoryType.QGC_Login);
				}

				public void SilentLogin ()
				{
						if (!ApiReady () && PlayerPrefs.HasKey ("_authToken"))
								return;

						string url = _baseURL + "/player";
						_authToken = PlayerPrefs.GetString ("_authToken");
						QGCNio.CreateSubmitWWW (url, null, _authToken, CategoryType.QGC_Login);
				}
		#endregion

		#region Register
				public void Register (string username, string password, string displayname)
				{
						DateTime time = DateTime.Now;
						string format = "yyyy-MM-dd";

						Register (username, password, displayname, "", "", "", time.ToString (format), "", "");
				}

				public void Register (string username, string password, string displayname, string firstname, string lastname, string email, string birthdate, string sex, string picture)
				{
						QGCPlayerSend pls = new QGCPlayerSend ();
						pls.PlayerUsername = username;
						pls.PlayerPassword = password;
						pls.PlayerDisplayName = displayname;
						pls.PlayerFirstname = firstname;
						pls.PlayerLastname = lastname;
						pls.PlayerEmail = email;
						pls.PlayerBirthdate = birthdate;
						pls.PlayerSex = sex;
						pls.PlayerPicture = picture;
						Register (pls);
				}

				public void Register (QGCPlayerSend pls)
				{
						if (!ApiReady ())
								return;
						if (string.IsNullOrEmpty (pls.PlayerUsername) || string.IsNullOrEmpty (pls.PlayerPassword) || string.IsNullOrEmpty (pls.PlayerDisplayName)) {
								API.LogWarning ("Mandatory fields must be completed");
								return;
						}
						string url = _baseURL + "/register";
						
						pls.PlayerPlatform = QGCUtils.GetSystem ();
						string userObj = JsonConvert.SerializeObject (pls);
						_authToken = encodeAuth (pls.PlayerUsername + ":" + pls.PlayerPassword);

						QGCNio.CreateSubmitWWW (url, userObj, CategoryType.QGC_Register);
				}
		#endregion

		#region Update
				public void UpdateProfile (string password, string displayname, string firstname, string lastname, string email, string birthdate, string sex, string picture)
				{
						QGCPlayerSend pls = new QGCPlayerSend ();
						pls.PlayerPassword = password;
						pls.PlayerDisplayName = displayname;
						pls.PlayerFirstname = firstname;
						pls.PlayerLastname = lastname;
						pls.PlayerEmail = email;
						pls.PlayerBirthdate = birthdate;
						pls.PlayerSex = sex;
						pls.PlayerPicture = picture;
						UpdateProfile (pls);
				}
		
				public void UpdateProfile (QGCPlayerSend pls)
				{
						if (!ApiReady ())
								return;
						if (string.IsNullOrEmpty (pls.PlayerDisplayName)) {
								API.LogWarning ("Mandatory fields must be completed");
								return;
						}
						string url = _baseURL + "/update";
			
						string userObj = JsonConvert.SerializeObject (pls);
			
						QGCNio.CreateSubmitWWW (url, userObj, _authToken, CategoryType.QGC_UpdateProfile);
				}
		#endregion

		#region SubmitScore
				public void SubmitScore (int score)
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;
						if (score < 0) {
								API.LogWarning ("Score must not be negative");
								return;
						}
						
						string url = _baseURL + "/score";
						QGCPlayerScoreSend pls = new QGCPlayerScoreSend ();
						pls.LeaderboardId = _leaderboardKey;
						pls.PlayerScore = score;
						string userObj = JsonConvert.SerializeObject (pls);
						QGCNio.CreateSubmitWWW (url, userObj, _authToken, CategoryType.QGC_SubmitScore);
				}
		#endregion
		
		#region GetAllScores
				public void GetAllScores (String leaderBoardKey)
				{
						_leaderboardKey = leaderBoardKey;
						GetAllScores (0, 10);
				}

				public void GetAllScores (String leaderBoardKey, int page, int size)
				{
						_leaderboardKey = leaderBoardKey;
						GetAllScores (page, size);
				}
		
				public void GetAllScores ()
				{
						GetAllScores (0, 10);
				}

				public void GetAllScores (int page, int size)
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;
			
						string url = _baseURL + "/scores?leaderboard=" + _leaderboardKey + "&page=" + page + "&size=" + size;
						QGCNio.CreateSubmitWWW (url, null, _authToken, CategoryType.QGC_GetAllScores);
				}
		#endregion
		
		#region GetPlayerScore
				public void GetPlayerScore (String leaderBoardKey)
				{
						_leaderboardKey = leaderBoardKey;
						GetPlayerScore ();
				}
		
				public void GetPlayerScore ()
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;
			
						string url = _baseURL + "/score?leaderboard=" + _leaderboardKey;
						QGCNio.CreateSubmitWWW (url, null, _authToken, CategoryType.QGC_GetPlayerScore);
				}
		#endregion

		#region GetAllAchievements
				public void GetAllAchievements ()
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;

						string url = _baseURL + "/achievements?game=" + _gameKey;
						QGCNio.CreateSubmitWWW (url, null, _authToken, CategoryType.QGC_GetAllAchievements);
				}
		#endregion

		#region GetAchievement
				public void GetAchievement (String achievementCode)
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;
			
						string url = _baseURL + "/achievement?code=" + achievementCode;
						QGCNio.CreateSubmitWWW (url, null, _authToken, CategoryType.QGC_GetAchievemnt);
				}
		#endregion

		#region UnlockAchievement
				public void UnlockAchievement (String achievementCode)
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;
			
						string url = _baseURL + "/unlockachievement";

						QGCAchievementUnlockSend pls = new QGCAchievementUnlockSend ();
						pls.AchievementCode = achievementCode;
						string userObj = JsonConvert.SerializeObject (pls);
						QGCNio.CreateSubmitWWW (url, userObj, _authToken, CategoryType.QGC_UnlockAchievement);
				}
		#endregion
		
		#region SubmitAchievement
				public void SubmitAchievement (String achievementCode, double unlockPoints)
				{
						if (!ApiReady () || !IsLoggedIn ())
								return;
			
						string url = _baseURL + "/achievement";
			
						QGCAchievementProgressSend pls = new QGCAchievementProgressSend ();
						pls.AchievementCode = achievementCode;
						pls.AchievementUnlockPoints = unlockPoints;
						string userObj = JsonConvert.SerializeObject (pls);
						QGCNio.CreateSubmitWWW (url, userObj, _authToken, CategoryType.QGC_SubmitAchievement);
				}
		#endregion	
		
		#region Utilities
				private bool ApiReady ()
				{
						if (_leaderboardKey.Equals ("")) {
								API.LogError ("Leaderboard Key not set. Open QGC_Settings to set key.");
								return false;
						}

						if (_gameKey.Equals ("")) {
								API.LogError ("Game Key not set. Open QGC_Settings to set key.");
								return false;
						}
			
						return true;
				}

				private bool IsLoggedIn ()
				{
						return API.IsLoggedIn ();
				}
		
				private String encodeAuth (String plainAuth)
				{
						byte[] bytesToEncode = Encoding.UTF8.GetBytes (plainAuth);
						return Convert.ToBase64String (bytesToEncode);
				}
		#endregion
		#region Events
				void OnPlayerLogin (LoginEvent e)
				{
						if (e.ErrorInfo == null) {
								PlayerPrefs.SetString ("_authToken", _authToken);
								PlayerPrefs.Save ();
						} 
				}

				void OnPlayerRegistered (RegisterEvent e)
				{
						if (e.ErrorInfo == null) {
								PlayerPrefs.SetString ("_authToken", _authToken);
								PlayerPrefs.Save ();
						}
				}


		#endregion
		}
}
