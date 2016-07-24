using UnityEngine;
using System.Collections;

public class AgglomeratePress : MonoBehaviour {
	public GeologySelect GeologyButtons;
	void Start(){
		this.transform.renderer.enabled=false;
	}
	void OnMouseDown(){
		if (GeologyButtons.geologyButtonSelected) {
			this.transform.renderer.enabled=false;
			GeologyButtons.agglomeratePress (transform.name,  this.gameObject);
				}
	}
	public void agglomerateInfo(){
		Application.OpenURL ("www.britannica.com/EBchecked/topic/9049/agglomerate");


	}

}
