using UnityEngine;
using System.Collections;

public class DiamictonPress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.diamictonPress (transform.name, this.gameObject);
				}
	}

	public void diamictonInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/54604/basalt");
	}
	
}
