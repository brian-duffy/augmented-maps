////////////////////////////////////////////////////////////////////////////////
//  
// @module <module_name>
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class AndroidAdMobController  {

	private static bool IsInited = false ;

	//--------------------------------------
	// INITIALIZE
	//--------------------------------------

	public static void StartAdMob(string id, int gravity)  {

		if(IsInited) {
			Debug.LogWarning ("StartAdMob shoudl be called only once. Call ignored");
			return;
		}
		AndroidNative.StartAdMob (id, gravity);
		IsInited = true;
	}

	//--------------------------------------
	//  PUBLIC METHODS
	//--------------------------------------

	

	public static void HideAd() { 
		if(!IsInited) {
			Debug.LogWarning ("StartAdMob shoudl be called before you can HideAd");
			return;
		}

		AndroidNative.HideAd ();
	}

	public static void ShowAd() { 
		if(!IsInited) {
			Debug.LogWarning ("StartAdMob shoudl be called before you can ShowAd");
			return;
		}


		AndroidNative.ShowAd ();
	}


	public static void Refresh() { 
		if(!IsInited) {
			Debug.LogWarning ("StartAdMob shoudl be called before you can Refresh");
			return;
		}


		AndroidNative.RefreshAd ();
	}

	
	//--------------------------------------
	//  GET/SET
	//--------------------------------------
	
	//--------------------------------------
	//  EVENTS
	//--------------------------------------
	
	//--------------------------------------
	//  PRIVATE METHODS
	//--------------------------------------
	
	//--------------------------------------
	//  DESTROY
	//--------------------------------------

}
