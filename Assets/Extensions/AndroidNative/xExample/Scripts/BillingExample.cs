////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class BillingExample : MonoBehaviour {




	void OnGUI() {
		if(GUI.Button(new Rect(180, 10, 150, 50), "Init Billing")) {
			GPaymnetManagerExample.init ();
		}


		if(GUI.Button(new Rect(180, 70, 150, 50), "Test Succses Purchase")) {
			if(GPaymnetManagerExample.isInited) {
				AndroidInAppPurchaseManager.instance.purchase (GPaymnetManagerExample.ANDROID_TEST_PURCHASED);
			} else {
				AndroidMessage.Create("Error", "PaymnetManagerExample not yet inited");
			}

		}

		if(GUI.Button(new Rect(180, 130, 150, 50), "Test Fail Purchase")) {
			if(GPaymnetManagerExample.isInited) {
				AndroidInAppPurchaseManager.instance.purchase (GPaymnetManagerExample.ANDROID_TEST_ITEM_UNAVALIABLE);
			} else {
				AndroidMessage.Create("Error", "PaymnetManagerExample not yet inited");
			}
		}


		if(GUI.Button(new Rect(180, 190, 150, 50), "Consume Product")) {

			if(GPaymnetManagerExample.isInited) {
				if(AndroidInAppPurchaseManager.instance.inventory.IsProductPurchased(GPaymnetManagerExample.ANDROID_TEST_PURCHASED)) {
					GPaymnetManagerExample.consume (GPaymnetManagerExample.ANDROID_TEST_PURCHASED);
				} else {
					AndroidMessage.Create("Error", "You do not own product to consume it");
				}

			} else {
				AndroidMessage.Create("Error", "PaymnetManagerExample not yet inited");
			}
		}


		/*************************/

		Color c = GUI.color;
		GUI.color = Color.green;
		if(GUI.Button(new Rect(10, 310, 150, 50), "Play Service Example")) {

			Application.LoadLevel ("PlayServiceExample");

		}


		if(GUI.Button(new Rect(170, 310, 150, 50), "Other Examples")) {

			Application.LoadLevel ("OtherFeaturesExample");

		}

		GUI.color = Color.red;

		if(GUI.Button(new Rect(330, 310, 150, 50), "ExitApp")) {
			Application.Quit ();
		}

		GUI.color = c;



	}


}