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
Method:  
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
Method:  
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
Method:  
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

