using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public bool focusModeSet;
	public bool mFlashEnabled = false;
	// Use this for initialization
	void Start () {
				//bool to set phone camera autofocus to auto
				focusModeSet = CameraDevice.Instance.SetFocusMode (
		     CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
				focusModeSet = true;
				if (!focusModeSet) {
						Debug.Log ("Failed to set focus mode (unsupported mode).");
				}

		}
	
	// Update is called once per frame

		void Update () {
			if (Input.GetMouseButtonDown (0)) {
		
						//if (madeit) {
						//		Vector3 StartPosition = transform.position;
						//		Vector3 targPos = myTarget.position;
						//		float speed = 30.5f;
						//		// get ray from camera in to scene at the mouse position
								//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

						//		Camera.mainCamera.transform.position = Vector3.Lerp (StartPosition, targPos, Time.deltaTime * speed);
						}

						//		if (myTarget.position.x == transform.position.x){
						//			madeit = false;
						//			}
				
				}




				//RaycastHit hit;
				
				// hardcoded "zoom" distance.
				//float zoomDist = 15.0f;
				
				// Raycast from camera to mouse cursor, if object hit, zoom.
				//if (Physics.Raycast(ray,out hit,Mathf.Infinity)){       
					// Create a second ray from the hit object back out, zoom the camera along this ray.
				//	Ray EndPosition = new Ray(hit.point,hit.normal);
				//	float t = 10.0f;
				//Vector3 end = EndPosition.GetPoint;
				//	Camera.mainCamera.transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
				
			
		

	public void controlFlash(){
		if (!mFlashEnabled)
		{
			// Turn on flash if it is currently disabled.
			CameraDevice.Instance.SetFlashTorchMode(true);

			mFlashEnabled = true;
			focusModeSet = CameraDevice.Instance.SetFocusMode (
				CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
			focusModeSet = true;
		}
		else
		{
			// Turn off flash if it is currently enabled.
			CameraDevice.Instance.SetFlashTorchMode(false);
			mFlashEnabled = false;

		}
		}

}
