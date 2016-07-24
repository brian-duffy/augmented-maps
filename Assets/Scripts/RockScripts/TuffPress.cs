using UnityEngine;
using System.Collections;

public class TuffPress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.tuffPress (transform.name,  this.gameObject);	
				}
	}
	
	public void daciteInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/149437/dacite");
	}	
}
