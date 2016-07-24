using UnityEngine;
using System.Collections;

public class RhyolitePress : MonoBehaviour {

	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.rhyolitePress (transform.name,  this.gameObject);
				}
	}
	
	public void rhyoliteInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/501884/rhyolite");
	}
}
