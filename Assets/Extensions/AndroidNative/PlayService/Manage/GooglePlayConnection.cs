////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;


public class GooglePlayConnection : Singletone<GooglePlayConnection> {


	public const int CLIENT_NONE = 0x00;
	public const int CLIENT_GAMES = 0x01;
	public const int CLIENT_PLUS = 0x02;
	public const int CLIENT_APPSTATE = 0x04;
	public const int CLIENT_ALL = CLIENT_GAMES | CLIENT_PLUS | CLIENT_APPSTATE;



	public const string PLAYER_SIGN_IN_SUCCEEDED = "player_sign_in_succeeded";
	public const string PLAYER_SIGN_IN_FAILED    = "player_sign_in_failed";


	public const string PLAYER_CONNECTED       = "player_connected";
	public const string PLAYER_DISCONNECTED    = "player_disconnected";


	private static GPConnectionState _state = GPConnectionState.STATE_UNCONFIGURED;


	//--------------------------------------
	// INITIALIZE
	//--------------------------------------


	void Awake() {
		DontDestroyOnLoad(gameObject);
	}


	//--------------------------------------
	// PUBLIC API CALL METHODS
	//--------------------------------------

	public void start(int clientsToUse) {

		if(Application.platform != RuntimePlatform.Android) {
			//ignoring for other platfroms
			return;
		}

		if (0 != (clientsToUse & CLIENT_GAMES))  {
			GooglePlayManager.instance.Create ();
		}

		if (0 != (clientsToUse & CLIENT_APPSTATE))  {
			GoogleCloudManager.instance.Create ();
		}


		AndroidNative.startPlayService (clientsToUse);
	}
	

	public void connect() {
		AndroidNative.playServiceConnect ();
	}

	public void disconnect() {
		AndroidNative.playServiceDisconnect ();
	}


	//--------------------------------------
	// PUBLIC METHODS
	//--------------------------------------


	public static bool CheckState() {
		switch(_state) {
			case GPConnectionState.STATE_CONNECTED:
			return true;
			case GPConnectionState.STATE_DISCONNECTED:
			instance.connect ();
			return false;
			default:
			return false;
		}
	}



	//--------------------------------------
	// GET / SET
	//--------------------------------------

	public static GPConnectionState state {
		get {
			return _state;
		}
	}


	//--------------------------------------
	// EVENTS
	//--------------------------------------


	private void OnSignInFailed() {
		dispatch (PLAYER_SIGN_IN_FAILED);
		Debug.Log ("GooglePlayManager -> PLAYER_SIGN_IN_FAILED");
	}

	private void OnSignInSucceeded() {
		dispatch (PLAYER_SIGN_IN_SUCCEEDED);
		Debug.Log ("GooglePlayManager -> PLAYER_SIGN_IN_FAILED");
	}


	private void OnStateChange(string data) {
		int id = System.Convert.ToInt32 (data);
		switch(id) {
			case 0:
			_state = GPConnectionState.STATE_UNCONFIGURED;
			break;
			case 1:
			_state = GPConnectionState.STATE_DISCONNECTED;
			dispatch (PLAYER_DISCONNECTED);
			break;
			case 2:
			_state = GPConnectionState.STATE_CONNECTING;
			break;
			case 3:
			_state = GPConnectionState.STATE_CONNECTED;
			dispatch (PLAYER_CONNECTED);
			break;

		}

		Debug.Log("State Changed -> " + _state.ToString());
	}






}
