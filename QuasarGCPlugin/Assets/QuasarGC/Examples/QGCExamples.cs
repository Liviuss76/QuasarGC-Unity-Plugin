using UnityEngine;
using System;
using System.Collections;
using QGC;

public class QGCExamples : MonoBehaviour
{
		private string username = "";
		private string password = "";
		private string displayname = "";
		private string firstname = "";
		private string lastname = "";
		private string email = "";
		private string birthdate = "";
		private string sex = "";
		private string picture = "";
		private string playerscore = "";
		private string achievementcode = "";
		private string achievementunlockpoints = "";

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
		void OnEnable ()
		{
				QGC.QGCEvents.instance.AddListener<LoginEvent> (OnPlayerLogin);			
				QGC.QGCEvents.instance.AddListener<RegisterEvent> (OnPlayerRegistered);	
				QGC.QGCEvents.instance.AddListener<UpdateProfileEvent> (OnUpdateProfile);
				QGC.QGCEvents.instance.AddListener<GetAllScoresEvent> (OnGetAllScores);
				QGC.QGCEvents.instance.AddListener<GetPlayerScoreEvent> (OnGetPlayerScore);
				QGC.QGCEvents.instance.AddListener<GetAllAchievementsEvent> (OnGetAllAchievements);
				QGC.QGCEvents.instance.AddListener<GetPlayerAchievementEvent> (OnGetPlayerAchievement);
				QGC.QGCEvents.instance.AddListener<AchievementUnlockedEvent> (OnUnlockAchievement);
				QGC.QGCEvents.instance.AddListener<AchievementSubmitEvent> (OnSubmitAchievement);
		
				
		}
	
		void OnDisable ()
		{
				QGC.QGCEvents.instance.RemoveListener<LoginEvent> (OnPlayerLogin);
				QGC.QGCEvents.instance.RemoveListener<RegisterEvent> (OnPlayerRegistered);
				QGC.QGCEvents.instance.RemoveListener<UpdateProfileEvent> (OnUpdateProfile);		
				QGC.QGCEvents.instance.RemoveListener<GetAllScoresEvent> (OnGetAllScores);
				QGC.QGCEvents.instance.RemoveListener<GetPlayerScoreEvent> (OnGetPlayerScore);
				QGC.QGCEvents.instance.RemoveListener<GetAllAchievementsEvent> (OnGetAllAchievements);
				QGC.QGCEvents.instance.RemoveListener<GetPlayerAchievementEvent> (OnGetPlayerAchievement);
				QGC.QGCEvents.instance.RemoveListener<AchievementUnlockedEvent> (OnUnlockAchievement);
				QGC.QGCEvents.instance.RemoveListener<AchievementSubmitEvent> (OnSubmitAchievement);
				
		}
	
		void OnPlayerLogin (LoginEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to login player:" + e.ErrorInfo.ErrorMessage);
				} else {	
						Debug.Log ("LoggedIn - Player ID:" + QGC.API.Player.PlayerId + " Player Username:" + QGC.API.Player.PlayerUsername + " Player Firstname:" + QGC.API.Player.PlayerFirstname + " Player Lastname:" + QGC.API.Player.PlayerLastname + " Player Blocked:" + QGC.API.Player.PlayerBlocked);
				}
		}

		void OnPlayerRegistered (RegisterEvent e)
		{
				if (e.ErrorInfo != null) {

						Debug.Log ("Failed to register player:" + e.ErrorInfo.ErrorMessage);
				} else {	
						Debug.Log ("Registered - Player ID:" + QGC.API.Player.PlayerId + " Player Username:" + QGC.API.Player.PlayerUsername + " Player Firstname:" + QGC.API.Player.PlayerFirstname + " Player Lastname:" + QGC.API.Player.PlayerLastname + " Player Blocked:" + QGC.API.Player.PlayerBlocked);
				}
		}

		void OnUpdateProfile (UpdateProfileEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to update player:" + e.ErrorInfo.ErrorMessage);
				} else {	
						Debug.Log ("Updated - Player ID:" + QGC.API.Player.PlayerId + " Player Username:" + QGC.API.Player.PlayerUsername + " Player Firstname:" + QGC.API.Player.PlayerFirstname + " Player Lastname:" + QGC.API.Player.PlayerLastname + " Player Blocked:" + QGC.API.Player.PlayerBlocked);
				}
		}

		void OnGetAllScores (GetAllScoresEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to fetch scores from server:" + e.ErrorInfo.ErrorMessage);
				} else {
						foreach (QGCPlayerScore ps in e.PlayerScores) {
								Debug.Log ("Player:" + ps.PlayerDisplayName + " Score:" + ps.PlayerScore + " Rank:" + ps.PlayerRank + " Platform:" + ps.PlayerPlatform);
						}
				}
		}

		void OnGetPlayerScore (GetPlayerScoreEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to fetch player score from server:" + e.ErrorInfo.ErrorMessage);
				} else {
						
						Debug.Log ("Player:" + e.PlayerScore.PlayerDisplayName + " Score:" + e.PlayerScore.PlayerScore + " Rank:" + e.PlayerScore.PlayerRank + " Scores Count:" + e.PlayerScore.ScoresCount + " Platform:" + e.PlayerScore.PlayerPlatform);
				}
		}

		void OnGetAllAchievements (GetAllAchievementsEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to fetch achievements from server:" + e.ErrorInfo.ErrorMessage);
				} else {
						foreach (QGCAchievement pa in e.PlayerAchievements) {
								Debug.Log (pa);
						}
				}
		}

		void OnGetPlayerAchievement (GetPlayerAchievementEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to fetch achievement from server:" + e.ErrorInfo.ErrorMessage);
				} else {
						Debug.Log (e.PlayerAchievement);
						
				}
		}

		void OnUnlockAchievement (AchievementUnlockedEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Failed to unlock achievement:" + e.ErrorInfo.ErrorMessage);
				} else {
						Debug.Log (e.PlayerAchievement);
			
				}
		}

		void OnSubmitAchievement (AchievementSubmitEvent e)
		{
				if (e.ErrorInfo != null) {
						Debug.Log ("Achievement submition failed:" + e.ErrorInfo.ErrorMessage);
				} else {
						Debug.Log (e.PlayerAchievementProgress);
			
				}
		}
	
		void OnGUI ()
		{
				GUI.Box (new Rect (10, 10, 330, 80), "Auth");
				GUI.Label (new Rect (20, 40, 100, 20), "Username:");
				GUI.Label (new Rect (20, 60, 100, 20), "Password:");
				username = GUI.TextField (new Rect (120, 40, 100, 20), username, 25);
				password = GUI.TextField (new Rect (120, 60, 100, 20), password, 25);
				
				if (GUI.Button (new Rect (230, 40, 100, 25), "Login")) {
						QGC.API.Login (username, password);
				}


				GUI.Box (new Rect (340, 10, 330, 280), "Register");
				GUI.Label (new Rect (350, 40, 100, 20), "*Username:");
				GUI.Label (new Rect (350, 60, 100, 20), "*Password:");
				GUI.Label (new Rect (350, 80, 100, 20), "*Displayname:");
				GUI.Label (new Rect (350, 100, 100, 20), "Firstname:");
				GUI.Label (new Rect (350, 120, 100, 20), "Lastname:");
				GUI.Label (new Rect (350, 140, 100, 20), "Email:");
				GUI.Label (new Rect (350, 160, 100, 20), "Birthdarte:");
				GUI.Label (new Rect (350, 180, 100, 20), "(yyyy-MM-dd)");
				GUI.Label (new Rect (350, 200, 100, 20), "Sex:");
				GUI.Label (new Rect (350, 220, 100, 20), "Picture:");
				GUI.Label (new Rect (350, 240, 100, 20), "(base 64 string)");
				username = GUI.TextField (new Rect (450, 40, 100, 20), username, 25);
				password = GUI.TextField (new Rect (450, 60, 100, 20), password, 25);
				displayname = GUI.TextField (new Rect (450, 80, 100, 20), displayname, 25);
				firstname = GUI.TextField (new Rect (450, 100, 100, 20), firstname, 25);
				lastname = GUI.TextField (new Rect (450, 120, 100, 20), lastname, 25);
				email = GUI.TextField (new Rect (450, 140, 100, 20), email, 25);
				birthdate = GUI.TextField (new Rect (450, 160, 100, 20), birthdate, 25);
				sex = GUI.TextField (new Rect (450, 200, 100, 20), sex, 25);		
				picture = GUI.TextArea (new Rect (450, 220, 100, 20), picture);

				if (GUI.Button (new Rect (560, 40, 100, 25), "Register Quick")) {
						QGC.API.Register (username, password, displayname);
				}

				if (GUI.Button (new Rect (560, 60, 100, 25), "Register Full")) {
						
						QGC.API.Register (username, password, displayname, firstname, lastname, email, birthdate, sex, picture);
				}

				if (GUI.Button (new Rect (560, 80, 100, 25), "Update Profile")) {
			
						QGC.API.UpdateProfile (password, displayname, firstname, lastname, email, birthdate, sex, picture);
				}
		
				GUI.Box (new Rect (10, 100, 330, 300), "API");
				if (GUI.Button (new Rect (20, 120, 110, 25), "GetAllScores")) {
						QGC.API.GetAllScores ();
				}	
				
				if (GUI.Button (new Rect (20, 150, 110, 25), "GetPlayerScore")) {
						QGC.API.GetPlayerScore ();
				}

				GUI.Label (new Rect (20, 180, 100, 20), "Submit score:");
				playerscore = GUI.TextField (new Rect (120, 180, 100, 20), playerscore, 25);
				
				if (GUI.Button (new Rect (230, 180, 100, 25), "SubmitScore")) {
						QGC.API.SubmitScore (int.Parse (playerscore));
				}

				if (GUI.Button (new Rect (20, 210, 140, 25), "GetAllAchievements")) {
						QGC.API.GetAllAchievements ();
				}
		
				GUI.Label (new Rect (20, 240, 100, 20), "Code:");
				achievementcode = GUI.TextField (new Rect (70, 240, 120, 20), achievementcode, 25);
		
				if (GUI.Button (new Rect (200, 240, 130, 25), "GetAchievement")) {
						QGC.API.GetAchievement (achievementcode);
				}

				GUI.Label (new Rect (20, 270, 100, 20), "Code:");
				achievementcode = GUI.TextField (new Rect (70, 270, 120, 20), achievementcode, 25);
		
				if (GUI.Button (new Rect (200, 270, 130, 25), "UnlockAchievement")) {
						QGC.API.UnlockAchievement (achievementcode);
				}

				GUI.Label (new Rect (20, 320, 100, 20), "Code:");
				achievementcode = GUI.TextField (new Rect (70, 320, 120, 20), achievementcode, 25);

				GUI.Label (new Rect (20, 350, 100, 20), "Points:");
				achievementunlockpoints = GUI.TextField (new Rect (70, 350, 120, 20), achievementunlockpoints, 25);
		
				if (GUI.Button (new Rect (200, 320, 130, 25), "SubmitAchievement")) {
						QGC.API.SubmitAchievement (achievementcode, Double.Parse (achievementunlockpoints));
				}
		
		}
}
