using UnityEngine;
using System.Collections;

public class clickedSphere : MonoBehaviour {
	internal bool zoomSphereOne = false;
	Transform rotSpeed ;
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 10, 0);
}

	void OnMouseDown(){
		zoomSphereOne = true;
		//zoomFunc ();
		Debug.Log ("ZOOM IS TRUE");
	}


	public	void backToMAP(){

		Application.LoadLevel ("Walk2");
	}
}