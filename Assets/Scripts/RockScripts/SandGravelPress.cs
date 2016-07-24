using UnityEngine;
using System.Collections;

public class SandGravelPress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
				if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.sandGravelPress (transform.name,  this.gameObject);
				}
		}

	public void sandGravelInfo(){
		Application.OpenURL ("https://www.mineralseducationcoalition.org/minerals/sand-and-gravel");
	}

}
