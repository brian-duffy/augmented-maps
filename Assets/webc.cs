using UnityEngine;
using System.Collections;

public class webc : MonoBehaviour {
	WebCamTexture  webcam = new WebCamTexture();

	// Use this for initialization
	void Start () {
		webcam.Play();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
