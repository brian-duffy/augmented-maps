////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoogleCloudManager : Singletone<GoogleCloudManager> {


	public const string STATE_DELETED     = "key_deleted";
	public const string STATE_UPDATED     = "state_updated";
	public const string STATE_LOADED      = "state_loaded";
	public const string STATE_RESOLVED    = "state_resolved";
	public const string STATE_CONFLICT    = "state_conflict";
	public const string ALL_STATES_LOADED = "all_states_loaded";

	private int _maxStateSize = -1;
	private int _maxNumKeys  = -1;

	private Dictionary<int, string> _states = new Dictionary<int, string>();

	//--------------------------------------
	// INITIALIZE
	//--------------------------------------


	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public void Create() {
		Debug.Log ("GoogleCloudManager was created");
	}


	//--------------------------------------
	// PUBLIC API CALL METHODS
	//--------------------------------------

	public  void loadAllStates() {
		AndroidNative.listStates ();
	}

	public void updateState(int stateKey, string data) {
		AndroidNative.updateState (stateKey, data);
	}

	public void resolveState(int stateKey, string resolvedData, string resolvedVersion) {
		AndroidNative.resolveState (stateKey, resolvedData, resolvedVersion);
	}

	public void deleteState(int stateKey)  {
		AndroidNative.deleteState (stateKey);
	}

	public void loadState(int stateKey)  {
		AndroidNative.loadState (stateKey);
	}

	//--------------------------------------
	// PUBLIC METHODS
	//--------------------------------------

	public string GetStateData(int stateKey) {
		if(_states.ContainsKey(stateKey)) {
			return _states [stateKey];
		} else {
			return "";
		}
	}
	


	//--------------------------------------
	// GET / SET
	//--------------------------------------

	public int maxStateSize {
		get {
			return _maxStateSize;
		}
	}


	public int maxNumKeys {
		get {
			return _maxNumKeys;
		}
	}

	public Dictionary<int, string> states {
		get {
			return _states;
		}
	} 




	//--------------------------------------
	// EVENTS
	//--------------------------------------

	private void OnAllStatesLoaded(string data) {

		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);

		Debug.Log ("OnAllStatesLoaded");
		Debug.Log (data);
		GoogleCloudResult result = new GoogleCloudResult (storeData [0]);
		if(storeData.Length > 1) {

			_states.Clear ();

			for(int i = 1; i < storeData.Length; i+=2) {
				Debug.Log ("iteration");
				if(storeData[i] == AndroidNative.DATA_EOF) {
					break;
				}

				PushStateData (storeData [i], storeData [i + 1]);
			}

			Debug.Log ("Loaded: " + _states.Count + " States");
		}

		Debug.Log ("disp");
		dispatch (ALL_STATES_LOADED, result);

	}

	private void OnStateConflict(string data) {
		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);

		GoogleCloudResult result = new GoogleCloudResult ("0", storeData [0]);
		if(result.isSuccess) {
			result.stateData          = storeData [1];
			result.serverConflictData = storeData [2];
			result.resolvedVersion    = storeData [3];

			PushStateData (storeData [0], storeData [1]);
		}

		//set state data storeData [2]
		dispatch (STATE_CONFLICT, result);
	}




	private void OnStateLoaded(string data) {
		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);


		GoogleCloudResult result = new GoogleCloudResult (storeData [0], storeData [1]);

		result.stateData = storeData [2];
		PushStateData (storeData [1], storeData [2]);


		//set state data storeData [2]
		dispatch (STATE_LOADED, result);
	}

	private void OnStateResolved(string data) {
		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);

		GoogleCloudResult result = new GoogleCloudResult (storeData [0], storeData [1]);

		result.stateData = storeData [2];
		PushStateData (storeData [1], storeData [2]);


		//set state data storeData [2]
		dispatch (STATE_RESOLVED, result);
	}

	private void OnStateUpdated(string data) {
		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);
		Debug.Log ("OnStateUpdated");
		GoogleCloudResult result = new GoogleCloudResult (storeData [0], storeData [1]);

		result.stateData = storeData [2];
		PushStateData (storeData [1], storeData [2]);


		//set state data storeData [2]
		dispatch (STATE_UPDATED, result);
	}

	private void OnKeyDeleted(string data) {
		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);

		GoogleCloudResult result = new GoogleCloudResult (storeData [0], storeData [1]);

		dispatch (STATE_DELETED, result);
	}

	private void OnCloudConnected(string data) {
		string[] storeData;
		storeData = data.Split(AndroidNative.DATA_SPLITTER [0]);

		Debug.Log ("Google Cloud is connected max state size: " + storeData[0] + " max state num " + storeData[1]);

		_maxNumKeys = System.Convert.ToInt32 (storeData[1]);
		_maxStateSize = System.Convert.ToInt32 (storeData[0]);

	}


	
	//--------------------------------------
	// PRIVATE METHODS
	//--------------------------------------
	

	private void PushStateData(string stateKey, string data) {
		PushStateData (System.Convert.ToInt32(stateKey), data);
	}

	private void PushStateData(int stateKey, string data) {
		if(_states.ContainsKey(stateKey)) {
			_states [stateKey] = data;
		} else {
			_states.Add (stateKey, data);
		}
	}

}
