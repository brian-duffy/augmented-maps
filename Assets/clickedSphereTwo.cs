using UnityEngine;
using System.Collections;

public class clickedSphereTwo : MonoBehaviour {
	internal bool zoomSphereTwo = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0, 10, 0);
	}
	
	void OnMouseDown(){
		zoomSphereTwo = true;
		
		//zoomFunc ();
	}
	
}