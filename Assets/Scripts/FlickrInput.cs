using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FlickrInput : MonoBehaviour {
	public Text inputText;
	public GameObject text;
	public LoadFlickrImages loadFlickr;


	// Use this for initialization
	void Start () {
		inputText = text.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void inputFlickrEnd(string input){
	
		inputText.text = input;
		loadFlickr.flickrUserLoad (input);

	}
}
