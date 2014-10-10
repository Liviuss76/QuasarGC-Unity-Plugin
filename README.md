# QuasarGC Plugin for Unity

The QuasarGC plugin for Unity&reg; is an open-source project whose goal
is to provide a plugin that allows game developers to integrate with
the [QuasarGC Server](https://github.com/Liviuss76/QuasarGC) API from a game written in Unity&reg;.  

_Unity&reg; is a trademark of Unity Technologies._  

## Overview


The QuasarGC plugin for Unity allows you to access the [QuasarGC Server](https://github.com/Liviuss76/QuasarGC) API from Unity's environment.  
The plugin provides support for the following features of the [QuasarGC Server](https://github.com/Liviuss76/QuasarGC):  

* Register/Update/Login player  
* Post/Retrieve score to/from leaderboard  
* Unlock/Retrieve/Increment achievement  

System requirements:  
* Unity&reg; 4.3 or above  
* Trusted SSL certificate installed on QuasarGC (on Android you won’t be able to send/receive WWW with self-signed certificates)


## Configure Your Game

To use the plugin, you must first configure your game/leaderboard and achievements in the 
QuasarGC Admin Console.  
Drag the “QGCInit” prefab, supplied with plugin, into the scene and in inspector set the url of the QGC Server, keys for the Game and Leaderboard.  


## API

#### Login
Methods:  
```csharp
//Login the Player
public static void Login (string username, string password)

//On first successful Login, credentials will be saved in PlayerPrefs and reused.
public static void SilentLogin ()
```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...
    	string username;
    	string password;
	...

	QGC.API.Login (username, password);

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<LoginEvent> (OnPlayerLogin);			
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<LoginEvent> (OnPlayerLogin);	
	}

	void OnPlayerLogin (LoginEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to login player:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log ("LoggedIn - Player ID:" + QGC.API.Player.PlayerId );
			...
		}
	}
```
  
  
#### Registration
Methods:  
```csharp
//Register Player with minimum required fields
public static void Register (string username, string password, string displayname)

//Register Player with all fields
public static void Register (string username, string password, string displayname, string firstname, string lastname, string email, string birthdate, string sex, string picture)

//Register Player
public static void Register (QGCPlayerSend pls)

//Check if a player credentials are present in PlayerPrefs
public static bool IsRegistered ()

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...
	string username;
    	string password;
	...

	QGC.API.Register (username, password, displayname);

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<RegisterEvent> (OnPlayerRegistered);			
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<RegisterEvent> (OnPlayerRegistered);	
	}

	void OnPlayerRegistered (RegisterEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to register player:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log ("Registered - Player ID:" + QGC.API.Player.PlayerId );
			...
		}
	}
```
  
  
#### Update profile
Methods:  
```csharp
//Update Player profile
public static void UpdateProfile (string password, string displayname, string firstname, string lastname, string email, string birthdate, string sex, string picture)
```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...
	string username;
    	string password;
	...

	QGC.API.UpdateProfile (password, displayname, firstname, lastname, email, birthdate, sex, picture);

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<UpdateProfileEvent> (OnUpdateProfile);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<UpdateProfileEvent> (OnUpdateProfile);	
	}

	void OnUpdateProfile (UpdateProfileEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to update player:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log (“Updated - Player ID:" + QGC.API.Player.PlayerId );
			...
		}
	}
```
  
  
#### Get All Scores
Methods:  
```csharp
//Get all scores
public static void GetAllScores ()

//Get all scores with offset
public static void GetAllScores (int page, int size)

//Get all scores for specific Leaderboard
public static void GetAllScores (String leaderBoardKey)

//Get all scores for specific Leaderboard with offset
public static void GetAllScores (String leaderBoardKey, int page, int size)

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...

	QGC.API.GetAllScores ();

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<GetAllScoresEvent> (OnGetAllScores);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<GetAllScoresEvent> (OnGetAllScores);	
	}

	void OnGetAllScores (GetAllScoresEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to fetch scores from server:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	foreach (QGCPlayerScore ps in e.PlayerScores) {
				Debug.Log ("Player:" + ps.PlayerDisplayName + " Score:" + ps.PlayerScore + " Rank:" + ps.PlayerRank + " Platform:" + ps.PlayerPlatform);
			}
			...
		}
	}
```
  
  
#### Get Player Score
Methods:  
```csharp
//Get player score
public static void GetPlayerScore ()

//Get player score for specific Leaderboard
public static void GetPlayerScore (String leaderBoardKey)

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...

	QGC.API.GetPlayerScore ();

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<GetPlayerScoreEvent> (OnGetPlayerScore);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<GetPlayerScoreEvent> (OnGetPlayerScore);	
	}

	void OnGetPlayerScore (GetPlayerScoreEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to fetch player score from server:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log ("Player:" + e.PlayerScore.PlayerDisplayName + " Score:" + e.PlayerScore.PlayerScore + " Rank:" + e.PlayerScore.PlayerRank + " Scores Count:" + e.PlayerScore.ScoresCount + " Platform:" + e.PlayerScore.PlayerPlatform);
			...
		}
	}
```
  
  
#### Submit Player Score
Methods:  
```csharp
//Submit player score
public static void SubmitScore (int score)

//Submit player score for specific Leaderboard
public static void SubmitScore (String leaderBoardKey, int score)

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...
	int score;
	...

	QGC.API.SubmitScore ( score )

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<GetPlayerScoreEvent> (OnGetPlayerScore);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<GetPlayerScoreEvent> (OnGetPlayerScore);	
	}

	void OnGetPlayerScore (GetPlayerScoreEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to fetch player score from server:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log ("Player:" + e.PlayerScore.PlayerDisplayName + " Score:" + e.PlayerScore.PlayerScore + " Rank:" + e.PlayerScore.PlayerRank + " Scores Count:" + e.PlayerScore.ScoresCount + " Platform:" + e.PlayerScore.PlayerPlatform);
			...
		}
	}
```


#### Get all achievements
Methods:  
```csharp
//Get all achievements
public static void GetAllAchievements ()

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...

	QGC.API.GetAllAchievements ();

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<GetAllAchievementsEvent> (OnGetAllAchievements);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<GetAllAchievementsEvent> (OnGetAllAchievements);	
	}

	void OnGetAllAchievements (GetAllAchievementsEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to fetch achievements from server:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	foreach (QGCAchievement pa in e.PlayerAchievements) {
				Debug.Log (pa);
			}
			...
		}
	}
```


#### Get achievement
Methods:  
```csharp
//Get achievement by Code
public static void GetAchievement (String achievementCode)

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...

	QGC.API.GetAchievement (achievementcode);

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<GetPlayerAchievementEvent> (OnGetPlayerAchievement);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<GetPlayerAchievementEvent> (OnGetPlayerAchievement);	
	}

	void OnGetPlayerAchievement (GetPlayerAchievementEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to fetch achievement from server:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log (e.PlayerAchievement);
			...
		}
	}
```



#### Unlock achievement
Methods:  
```csharp
//Unlock achievement by code
public static void UnlockAchievement (String achievementCode)

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...

	QGC.API.UnlockAchievement (achievementcode);

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<AchievementUnlockedEvent> (OnUnlockAchievement);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<AchievementUnlockedEvent> (OnUnlockAchievement);	
	}

	void OnUnlockAchievement (AchievementUnlockedEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Failed to unlock achievement:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log (e.PlayerAchievement);
			...
		}
	}
```



#### Submit achievement progress
Methods:  
```csharp
//Submit achievement progress
public static void SubmitAchievement (String achievementCode, double unlockPoints)

```
Example:  
```csharp
	using UnityEngine;
	using QGC;
	...

	QGC.API.UnlockAchievement (achievementcode);

	...

	void OnEnable ()
	{
		QGC.QGCEvents.instance.AddListener<AchievementSubmitEvent> (OnSubmitAchievement);
	}
	
	void OnDisable ()
	{
		QGC.QGCEvents.instance.RemoveListener<AchievementSubmitEvent> (OnSubmitAchievement);	
	}

	void OnSubmitAchievement (AchievementSubmitEvent e)
	{
		if (e.ErrorInfo != null) {
			Debug.Log ("Achievement submission failed:" + e.ErrorInfo.ErrorMessage);
		} else {	
		 	Debug.Log (e.PlayerAchievementProgress);
			...
		}
	}
```