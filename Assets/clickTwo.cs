using UnityEngine;
using System.Collections;

public class clickTwo : MonoBehaviour {
	public GameObject image;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown(){
		Debug.Log ("Click");

		Application.LoadLevel ("ImageTwo");
		//if(Input.GetMouseDown(0)){
			// Whatever you want it to do.
		//	Debug.Log("This");
	//	}
				//this.gameObject.renderer.material.mainTexture = texture;//guiTexture = texture;
		}

	//void OnMouseOver()
	//{
//		Debug.Log ("This");
//	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
