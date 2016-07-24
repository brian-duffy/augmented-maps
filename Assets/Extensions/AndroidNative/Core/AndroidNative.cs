////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class AndroidNative {

	//--------------------------------------
	// Constants
	//--------------------------------------

	public const string DATA_SPLITTER = "|";
	public const string DATA_EOF = "endofline";
	
	//--------------------------------------
	// Goole Cloud
	//--------------------------------------

	public static void listStates() {
		CallActivityFunction("listStates");
	}

	public static void updateState(int stateKey, string data) {
		CallActivityFunction("updateState", stateKey.ToString(), data);
	}

	public static void resolveState(int stateKey, string resolvedData, string resolvedVersion) {
		CallActivityFunction("resolveState", stateKey.ToString(), resolvedData, resolvedVersion);
	}

	public static void deleteState(int stateKey)  {
		CallActivityFunction("deleteState", stateKey.ToString());
	}

	public static void loadState(int stateKey)  {
		CallActivityFunction("loadState", stateKey.ToString());
	}



	//--------------------------------------
	// Play Service
	//--------------------------------------
	

	public static void startPlayService (int clientsToUse) {
		CallActivityFunction("startPlayService", clientsToUse.ToString());
	}

	public static void playServiceConnect() {
		CallActivityFunction("playServiceConnect");
	}

	public static void playServiceDisconnect() {
		CallActivityFunction("playServiceDisconnect");
	}

	public static void showAchivmentsUI() {
		CallActivityFunction("showAchivments");
	}

	public static void showLeaderBoardsUI() {
		CallActivityFunction("showLeaderBoards");
	}

	public static void loadPlayer() {
		CallActivityFunction("loadPlayer");
	}


	public static void showLeaderBoard(string leaderboardName) {
		CallActivityFunction("showLeaderBoard", leaderboardName);
	}

	public static void showLeaderBoardById(string leaderboardId) {
		CallActivityFunction("showLeaderBoardById", leaderboardId);
	}


	public static void submitScore(string leaderboardName, int score) {
		CallActivityFunction("submitScore", leaderboardName, score.ToString());
	}

	public static void submitScoreById(string leaderboardId, int score) {
		CallActivityFunction("submitScore", leaderboardId, score.ToString());
	}

	public static void loadLeaderBoards() {
		CallActivityFunction("loadLeaderBoards");
	}

	public static void reportAchievement(string achievementName) {
		CallActivityFunction("reportAchievement", achievementName);
	}

	public static void reportAchievementById(string achievementId) {
		CallActivityFunction("reportAchievementById", achievementId);
	}
	

	public static void revealAchievement(string achievementName) {
		CallActivityFunction("revealAchievement", achievementName);
	}

	public static void revealAchievementById(string achievementId) {
		CallActivityFunction("revealAchievementById", achievementId);
	}

	public static void incrementAchievement(string achievementName, string numsteps) {
		CallActivityFunction("incrementAchievement", achievementName, numsteps);
	}

	public static void incrementAchievementById(string achievementId, string numsteps) {
		CallActivityFunction("incrementAchievementById", achievementId, numsteps);
	}

	public static void loadAchivments() {
		CallActivityFunction("loadAchivments");
	}

	//--------------------------------------
	// Billing
	//--------------------------------------


	public static void connectToBilling(string ids, string base64EncodedPublicKey) {
		CallActivityFunction("connectToBilling", ids, base64EncodedPublicKey);
	}
	

	public static void retrieveProducDetails() {
		CallActivityFunction("retrieveProducDetails");
	}


	public static void consume(string SKU) {
		CallActivityFunction("consume", SKU);
	}



	public static void purchase(string SKU) {
		CallActivityFunction("purchase", SKU, "");
	}

	public static void purchase(string SKU, string developerPayload) {
		CallActivityFunction("purchase", SKU, developerPayload);
	}

	
	//--------------------------------------
	//  MESSAGING
	//--------------------------------------


	public static void showDialog(string title, string message) {
		showDialog (title, message, "Yes", "No");
	}

	public static void showDialog(string title, string message, string yes, string no) {
		CallActivityFunction("showDialog", title, message, yes, no);
	}


	public static void showMessage(string title, string message) {
		showMessage (title, message, "Ok");
	}


	public static void showMessage(string title, string message, string ok) {
		CallActivityFunction("ShowMessage", title, message, ok);
	}



	public static void showRateDialog(string title, string message, string yes, string laiter, string no, string url) {
		CallActivityFunction("ShowRateDialog", title, message, yes, laiter, no, url);
	}



	//--------------------------------------
	// Other
	//--------------------------------------
	

	public static void StartAdMob(string id, int gravity) {
		CallActivityFunction("StartAdMob", id, gravity.ToString());
	}


	public static void HideAd() { 
		CallActivityFunction ("HideAd");
	}

	public static void ShowAd() { 
		CallActivityFunction ("ShowAd");
	}

	public static void RefreshAd() { 
		CallActivityFunction ("RefreshAd");
	}

	public static void ShowToastNotification(string text, int duration) {
		CallActivityFunction("ShowToastNotification", text, duration.ToString());
	}



	private static void CallActivityFunction(string methodName, params object[] args) {
       #if UNITY_ANDROID

		if(Application.platform != RuntimePlatform.Android) {
			return;
		}

		try {

			AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
			AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 

			jo.Call("runOnUiThread", new AndroidJavaRunnable(() => { jo.Call(methodName, args); }));


		} catch(System.Exception ex) {
			Debug.LogWarning(ex.Message);
		}
		#endif
	}

}
