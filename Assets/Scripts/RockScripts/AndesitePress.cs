using UnityEngine;
using System.Collections;

public class AndesitePress : MonoBehaviour {
	public GeologySelect GeologyButtons;

	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
						GeologyButtons.andesitePress (transform.name, this.gameObject);
				}
	}
	public void andesiteInfo(){
		Application.OpenURL ("http://www.britannica.com/EBchecked/topic/23727/andesite");
	}
	
}
