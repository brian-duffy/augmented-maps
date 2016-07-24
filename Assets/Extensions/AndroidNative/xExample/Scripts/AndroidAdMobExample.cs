////////////////////////////////////////////////////////////////////////////////
//  
// @module <module_name>
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class AndroidAdMobExample : MonoBehaviour {

	private const string MY_AD_UNIT_ID = "a1527f9855f2ed6";

	//--------------------------------------
	// INITIALIZE
	//--------------------------------------

	//--------------------------------------
	//  PUBLIC METHODS
	//--------------------------------------

	void OnGUI() {
		if(GUI.Button(new Rect(10, 70, 150, 50), "Initd Ad Mob Top")) {
			AndroidAdMobController.StartAdMob (MY_AD_UNIT_ID, AndroidGravity.TOP);
		}

		if(GUI.Button(new Rect(10, 130, 150, 50), "Initd Ad Mob Bottom")) {
			AndroidAdMobController.StartAdMob (MY_AD_UNIT_ID, AndroidGravity.BOTTOM);
		}


		if(GUI.Button(new Rect(170, 70, 150, 50), "Hide Ad")) {
			AndroidAdMobController.HideAd ();
		}


		if(GUI.Button(new Rect(170, 130, 150, 50), "Show Ad")) {
			AndroidAdMobController.ShowAd ();
		}

		if(GUI.Button(new Rect(170, 190, 150, 50), "Refresh Ad")) {
			AndroidAdMobController.Refresh ();
		}


		/*************************/


		Color c = GUI.color;
		GUI.color = Color.green;
		if(GUI.Button(new Rect(10, 310, 150, 50), "Play Service Example")) {
			Application.LoadLevel ("PlayServiceExample");
		}


		if(GUI.Button(new Rect(170, 310, 150, 50), "Billing Examples")) {

			Application.LoadLevel ("BillingExample");

		}

		GUI.color = Color.red;

		if(GUI.Button(new Rect(330, 310, 150, 50), "ExitApp")) {
			Application.Quit ();
		}

		GUI.color = c;


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
