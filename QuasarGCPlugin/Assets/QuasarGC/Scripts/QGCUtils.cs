using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace QGC
{
		public class QGCUtils
		{
				public static string GetSystem ()
				{
						#if UNITY_STANDALONE_OSX
						return "MAC";

						#elif UNITY_STANDALONE_WIN
		return "PC";
		
						#elif UNITY_WEBPLAYER
		return "WEBPLAYER";
		
						#elif UNITY_WII
		return "WII";
		
						#elif UNITY_IPHONE
		return "IPHONE";

						#elif UNITY_ANDROID
		return "ANDROID";
		
						#elif UNITY_PS3
		return "PS3";

						#elif UNITY_XBOX360
		return "XBOX";
		
						#elif UNITY_FLASH
		return "FLASH";
		
						#elif UNITY_STANDALONE_LINUX
		return "LINUX";
		
						#elif UNITY_NACL
		return "NACL";
		
						#elif UNITY_METRO
		return "WINDOWS_STORE_APP";
		
						#elif UNITY_WP8
		return "WINDOWS_PHONE_8";
		
						#elif UNITY_BLACKBERRY
		return "BLACKBERRY";
		
						#else
						return "UNKNOWN";
						#endif
				}	
				
		}
}