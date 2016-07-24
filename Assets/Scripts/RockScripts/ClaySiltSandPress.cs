using UnityEngine;
using System.Collections;

public class ClaySiltSandPress : MonoBehaviour {

	public GeologySelect GeologyButtons;
	
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
						GeologyButtons.claySiltSandPress (transform.name, this.gameObject);
				}
	}
	
	public void sandGravelInfo(){
		Application.OpenURL ("http://www.ext.colostate.edu/mg/gardennotes/214.html");
	}
	
}
