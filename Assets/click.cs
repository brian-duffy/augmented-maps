using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {
	public Transform sphereOne;
	public Transform sphereTwo;
	public clickedSphere sphereScript;
	public clickedSphereTwo sphereScriptTwo;
	public GameObject MainCamera;
	private float speed = 0.20f;
	WebCamTexture  webcam = new WebCamTexture();
	
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		zoomFunc ();
	}

	void zoomFunc(){
		int camposx = (int)Camera.main.transform.position.x;
		int camposy = (int)Camera.main.transform.position.y;
		int camposz = (int)Camera.main.transform.position.z;

		//		int camposy = (int)Camera.mainCamera.transform.position.y;

		if (sphereScript.zoomSphereOne) {
			//Stop AR Cam
			CameraDevice.Instance.Stop(); 
			//Initiate Main Camera to Zoom in

			//ACTIVATE THIS FOR FINAL
			webcam.Play();
			//DEACTIVATE THIS ONE
			//MainCamera.SetActive(true);

			//Lerp from Initial Camera position to spherical position in world coordinatess
			Camera.mainCamera.transform.position = Vector3.Lerp (Camera.mainCamera.transform.position, sphereOne.transform.position,speed);

			//Change from float to int to detect if the camera has reached the sphere coordinates
			int endposx = (int)sphereOne.transform.position.x;
			int endposy = (int)sphereOne.transform.position.y;
			int endposz = (int)sphereOne.transform.position.z;
			//If it has, load the correct level/scene
			if ((camposx - endposx) < 5 & (camposy - endposy) < 5 & (camposz - endposz) < 5)  {
					Application.LoadLevel ("ImageOne");
				}
		}

		if (sphereScriptTwo.zoomSphereTwo) {
			//Stop AR Cam
			CameraDevice.Instance.Stop(); 
			//Initiate Main Camera to Zoom in
			webcam.Play();	
			//Lerp from Initial Camera position to spherical position in world coordinatess
			Camera.mainCamera.transform.position = Vector3.Lerp (Camera.mainCamera.transform.position, sphereTwo.transform.position,speed);
			//Change from float to int to detect if the camera has reached the sphere coordinates
			int endposx = (int)sphereTwo.transform.position.x;
			int endposy = (int)sphereTwo.transform.position.y;
			int endposz = (int)sphereTwo.transform.position.z;
			//If it has, load the correct level/scene
			if ((camposx - endposx) < 5 & (camposy - endposy) < 5 & (camposz - endposz) < 5)  {
				
				Application.LoadLevel ("ImageTwo");
			}
		}
	}
}	

	

