# QuasarGC Plugin for Unity

The QuasarGC plugin for Unity&reg; is an open-source project whose goal
is to provide a plugin that allows game developers to integrate with
the [QuasarGC Server](https://github.com/Liviuss76/QuasarGC) API from a game written in Unity&reg;.  

_Unity&reg; is a trademark of Unity Technologies._  

## Overview


The QuasarGC plugin for Unity allows you to access the [QuasarGC Server](https://github.com/Liviuss76/QuasarGC) API from Unity's environment.  
The plugin provides support for the following features of the [QuasarGC Server](https://github.com/Liviuss76/QuasarGC):  

* Register/Login player  
* Post/Retrieve score to leaderboard  
* Unlock/Reveal/Increment achievement  

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
public static void Login (string username, string password)
```
Example:  
```csharp
	using UnityEngine;
	using QGC;
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


