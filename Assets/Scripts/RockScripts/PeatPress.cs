using UnityEngine;
using System.Collections;

public class PeatPress : MonoBehaviour {
	public GeologySelect GeologyButtons;

	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			GeologyButtons.peatPress (transform.name,  this.gameObject);
				}
		}

	public void peatInfo(){
		Application.OpenURL ("https://www.mineralseducationcoalition.org/minerals/sand-and-gravel");
	}

}
