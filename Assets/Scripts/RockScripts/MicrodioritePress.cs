using UnityEngine;
using System.Collections;

public class MicrodioritePress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.microdioritePress (transform.name,  this.gameObject);
				}
	}
	
	public void sandGravelInfo(){
		Application.OpenURL ("http://en.wikipedia.org/wiki/Diorite");
	}
	
}
