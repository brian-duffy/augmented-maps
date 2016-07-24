using UnityEngine;
using System.Collections;

public class DacitePress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.dacitePress (transform.name,  this.gameObject);
				}
	}
	
	public void daciteInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/149437/dacite");
	}
	
}
