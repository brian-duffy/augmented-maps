////////////////////////////////////////////////////////////////////////////////
//  
// @module Common Native Plugin 
// @author Osipov Stanislav lacost.st@gmail.com
//
////////////////////////////////////////////////////////////////////////////////

using System;


public class GoogleCloudResult {

	private GooglePlayResponceCode _response;
	private string _message;

	private int _stateKey;


	public string stateData;
	public string serverConflictData;
	public string resolvedVersion;

	//--------------------------------------
	// INITIALIZE
	//--------------------------------------

	public GoogleCloudResult(string code) {
		_response = PlayServiceUtil.GetGPCodeFromInt(System.Convert.ToInt32(code));
		_message = _response.ToString ();
	}

	public GoogleCloudResult (string code, string key) {
		_response = PlayServiceUtil.GetGPCodeFromInt(System.Convert.ToInt32(code));
		_message = _response.ToString ();

		_stateKey = System.Convert.ToInt32 (key);
	}
	

	//--------------------------------------
	// GET / SET
	//--------------------------------------

	public GooglePlayResponceCode response {
		get {
			return _response;
		}
	}

	public string message {
		get {
			return _message;
		}
	}

	public int stateKey {
		get {
			return _stateKey;
		}
	}


	public bool isSuccess  {
		get {
			return _response == GooglePlayResponceCode.STATUS_OK;
		}
	}

	public bool isFailure {
		get {
			return !isSuccess;
		}
	}

}


