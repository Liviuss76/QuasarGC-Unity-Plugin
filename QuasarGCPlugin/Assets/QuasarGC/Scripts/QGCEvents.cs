using System.Collections;
using System.Collections.Generic;

/*
Source: http://www.willrmiller.com/?p=87
*/

namespace QGC
{
		public class QGCEvents
		{
				static QGCEvents instanceInternal = null;

				public static QGCEvents instance {
						get {
								if (instanceInternal == null) {
										instanceInternal = new QGCEvents ();
								}
			
								return instanceInternal;
						}
				}
	
				public delegate void EventDelegate<T> (T e) where T : QGCEvent;

				private delegate void EventDelegate (QGCEvent e);
	
				private Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate> ();
				private Dictionary<System.Delegate, EventDelegate> delegateLookup = new Dictionary<System.Delegate, EventDelegate> ();
	
				public void AddListener<T> (EventDelegate<T> del) where T : QGCEvent
				{	
						if (delegateLookup.ContainsKey (del))
								return;
		
						EventDelegate internalDelegate = (e) => del ((T)e);
						delegateLookup [del] = internalDelegate;
		
						EventDelegate tempDel;
						if (delegates.TryGetValue (typeof(T), out tempDel)) {
								delegates [typeof(T)] = tempDel += internalDelegate; 
						} else {
								delegates [typeof(T)] = internalDelegate;
						}
				}
	
				public void RemoveListener<T> (EventDelegate<T> del) where T : QGCEvent
				{
						EventDelegate internalDelegate;
						if (delegateLookup.TryGetValue (del, out internalDelegate)) {
								EventDelegate tempDel;
								if (delegates.TryGetValue (typeof(T), out tempDel)) {
										tempDel -= internalDelegate;
										if (tempDel == null) {
												delegates.Remove (typeof(T));
										} else {
												delegates [typeof(T)] = tempDel;
										}
								}
			
								delegateLookup.Remove (del);
						}
				}
	
				public void Raise (QGCEvent e)
				{
						EventDelegate del;
						if (delegates.TryGetValue (e.GetType (), out del)) {
								del.Invoke (e);
						}
				}
		}
}
