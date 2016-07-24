using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class username : MonoBehaviour {

	public string usernameFlickr;
	UnityEngine.UI.InputField inputFieldFlickr;
	UnityEngine.UI.Text nameDisplay;

	// Update is called once per frame
	void Update () {
		usernameFlickr = inputFieldFlickr.name;

		print (inputFieldFlickr.ToString ());
	}
}
