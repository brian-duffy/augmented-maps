////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GPaymnetManagerExample : MonoBehaviour {

	private static bool _isInited = false;

	//--------------------------------------
	//  INITIALIZE
	//--------------------------------------
	

	public const string ANDROID_TEST_PURCHASED = "android.test.purchased";

	public const string ANDROID_TEST_CANCELED = "android.test.canceled";
	public const string ANDROID_TEST_REFUNDED = "android.test.refunded";
	public const string ANDROID_TEST_ITEM_UNAVALIABLE = "android.test.item_unavailable";

	//example
	//public const string base64EncodedPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq6+GSFhciS/LpPfZIWBSVJtLHkEdJGhsUJKMeSZ8oqDiCGztbxpRz53yZCB39oLOqlZy3OXNmrAd2jQ1Xe/3FHXYA6lxTHaL6GL9KznGAGflh8TOzpp/Hxfc+TS//E4PF45XeDy0pfRhwiNwDucD1Y2PHdObc+L84D1SqFsY7GS+I/0N48BuowRwIkdzFlzwdiUAaV9LP0TIeEoFx1XbNjSCzWLnCr0MwESp8iPlAwoCRfAkG+a7aJ5rR860TFqrx91kFVw9JyvnxmYfyVCk4v1OeDTc8/ZQ4ojo82aTvqUxgmaTWgfG1+PqIEPmcIP+O2yZol4WdQazbU1F46kFdwIDAQAB";

	public const string base64EncodedPublicKey = "REPLACE_WITH_YOUR_PUBLIC_KEY";



	public static void init() {


		//Filling product list
		AndroidInAppPurchaseManager.instance.addProduct(ANDROID_TEST_PURCHASED);
		AndroidInAppPurchaseManager.instance.addProduct(ANDROID_TEST_CANCELED);
		AndroidInAppPurchaseManager.instance.addProduct(ANDROID_TEST_REFUNDED);
		AndroidInAppPurchaseManager.instance.addProduct(ANDROID_TEST_ITEM_UNAVALIABLE);


		//listening for purchase and consume events
		AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_PURCHASED, OnProductPurchased);
		AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_PRODUCT_CONSUMED,  OnProductConsumed);

		//initilaizing store
		AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_BILLING_SETUP_FINISHED, OnBillingConnected);
		AndroidInAppPurchaseManager.instance.loadStore(base64EncodedPublicKey);



	}

	//--------------------------------------
	//  PUBLIC METHODS
	//--------------------------------------


	public static void purchase(string SKU) {
		AndroidInAppPurchaseManager.instance.purchase (SKU);
	}

	public static void consume(string SKU) {
		AndroidInAppPurchaseManager.instance.consume (SKU);
	}

	//--------------------------------------
	//  GET / SET
	//--------------------------------------

	public static bool isInited {
		get {
			return _isInited;
		}
	}


	//--------------------------------------
	//  EVENTS
	//--------------------------------------
	
	private static void OnProcessingPurchasedProduct(GooglePurchaseTemplate purchase) {
		//some stuff for processing product purchse. Add coins, unlock track, etc
	}

	private static void OnProcessingConsumeProduct(GooglePurchaseTemplate purchase) {
		//some stuff for processing product consume. Reduse tip anount, reduse gold token, etc
	}

	private static void OnProductPurchased(CEvent e) {
		BillingResult result = e.data as BillingResult;

		if(result.isSuccess) {
			AndroidMessage.Create ("Product Purchased", result.purchase.SKU);
			OnProcessingPurchasedProduct (result.purchase);
		} else {
			AndroidMessage.Create("Product Purchase Failed", result.response.ToString() + " " + result.message);
		}

		Debug.Log ("Purchased Responce: " + result.response.ToString() + " " + result.message);
	}


	private static void OnProductConsumed(CEvent e) {
		BillingResult result = e.data as BillingResult;

		if(result.isSuccess) {
			AndroidMessage.Create ("Product Consumed", result.purchase.SKU);
			OnProcessingConsumeProduct (result.purchase);
		} else {
			AndroidMessage.Create("Product Cousume Failed", result.response.ToString() + " " + result.message);
		}

		Debug.Log ("Cousume Responce: " + result.response.ToString() + " " + result.message);
	}
	

	private static void OnBillingConnected(CEvent e) {
		BillingResult result = e.data as BillingResult;
		AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_BILLING_SETUP_FINISHED, OnBillingConnected);


		if(result.isSuccess) {
			//Store connection is Successful. Next we loading product and customer purchasing details
			AndroidInAppPurchaseManager.instance.retrieveProducDetails();
			AndroidInAppPurchaseManager.instance.addEventListener (AndroidInAppPurchaseManager.ON_RETRIEVE_PRODUC_FINISHED, OnRetriveProductsFinised);
		} 

		AndroidMessage.Create("Connection Responce", result.response.ToString() + " " + result.message);
		Debug.Log ("Connection Responce: " + result.response.ToString() + " " + result.message);
	}




	private static void OnRetriveProductsFinised(CEvent e) {
		BillingResult result = e.data as BillingResult;
		AndroidInAppPurchaseManager.instance.removeEventListener (AndroidInAppPurchaseManager.ON_RETRIEVE_PRODUC_FINISHED, OnRetriveProductsFinised);

		if(result.isSuccess) {
			_isInited = true;
			AndroidMessage.Create("Success", "Billing init complete");
		} else {
			 AndroidMessage.Create("Connection Responce", result.response.ToString() + " " + result.message);
		}

		Debug.Log ("Connection Responce: " + result.response.ToString() + " " + result.message);

	}






















}
