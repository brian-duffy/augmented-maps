using UnityEngine;
using System.Collections;

public class Custom_VirtualButton : MonoBehaviour, IVirtualButtonEventHandler {
	
	public GameObject button;
	public WalkWay walkwayscript;
	private float walkOverview = 0;
	internal bool buttonPressed = false;
	// register buttons for event handling
	void Start() {
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		foreach (VirtualButtonBehaviour item in vbs) {
						item.RegisterEventHandler (this);	
			walkOverview = 0;
		}
	}

	void Update(){

		if (walkOverview == 1)
			walkwayscript.StartWalk();
		}
	#region VirtualButton
	
	// button is "pressed" so change color of Sphere
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {

				if (walkwayscript.playButtonBool){
					if (vb.VirtualButtonName == "startwalk") {
						walkOverview = 1;			
						button.SetActive(false);
						buttonPressed = true;
						walkwayscript.PlayButtonPressed ();
				}
		}
		}
	
	// change Sphere back to white
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		if (vb.VirtualButtonName=="startwalk")  {



		}
	}
	#endregion VirtualButton
}