using UnityEngine;
using System.Collections.Generic;

public class VirtualButtonEvent : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject Sphere; 
	// Use this for initialization
	void Start () {
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour> ();
		for (int i=0; i < vbs.Length; ++i) {vbs[i].RegisterEventHandler(this); }
		Sphere = transform.FindChild("Sphere").gameObject;
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		//s_Waypoints Name = new s_Waypoints ();
		
		//Name.Accell();

		if (vb.VirtualButtonName == "Blue") {
						Sphere.renderer.material.color = Color.red;
				}

		if (vb.VirtualButtonName == "Red") {
						Sphere.renderer.material.color = Color.red;
				}
			//Name.Accell();
			//Debug.Log ("Failed to set focus mode (unsupported mode).");

		}


	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){

				if (vb.VirtualButtonName == "Red") {

						Sphere.renderer.material.color = Color.white;
				}

				if (vb.VirtualButtonName == "Blue") {
				
					Sphere.renderer.material.color = Color.white;
				}
			}
}
