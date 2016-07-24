using UnityEngine;
using System.Collections;

public class show_arrows : MonoBehaviour {

	public WalkWay walkwayscript;
	public GameObject arrowOne;
	// Use this for initialization
	void Start () {
		arrowOne.renderer.enabled = false;
		arrowOne.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void show_arrows_func (){

		if (walkwayscript.WPindexPointer == 7){
			this.renderer.enabled = true;
			Debug.Log("Turn it off");
		}
	}

}
