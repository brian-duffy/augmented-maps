using UnityEngine;
using System.Collections;

public class BasaltPress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.basaltPress (transform.name,  this.gameObject);
				}
	}

	public void basaltInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/54604/basalt");
	}
	
}
