using UnityEngine;
using System.Collections;

public class GravelPress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.gravelPress (transform.name,  this.gameObject);
				}
	}
	public void gravelInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/242331/gravel");
	}
	
}
