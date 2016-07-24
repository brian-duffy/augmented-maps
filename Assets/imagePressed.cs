using UnityEngine;
using System.Collections;
using UiImage = UnityEngine.UI.Image;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class imagePressed : MonoBehaviour {
	private bool firstpress = true;
	private Vector2 startSize;
	private Vector2 startPos;
	public Transform tester;
	public swipeGesture swipeScript;
	public LoadFlickrImages latlongscript;
	public Camera mainCamera;
	private float duration;
	private int i;
	internal bool shortpress = true;
	RaycastHit hit = new RaycastHit();
	// Use this for initialization
	void Start () {
		UiImage img = this.gameObject.GetComponent<UiImage> ();
		startSize = img.rectTransform.sizeDelta;
		startPos = img.rectTransform.position;
	}

	public void enlargeImage(){
		shortpress = false;
		if (firstpress) {
				UiImage img = this.gameObject.GetComponent<UiImage> ();
				img.rectTransform.sizeDelta = new Vector2 (2560, 1440);
				//WIDTH, HEIGHT, X, Y, 
				img.rectTransform.position = new Vector2 (1280, 720); // 1200, 700
				firstpress = false;		
			} 
			else if (firstpress == false) {
				UiImage img = this.gameObject.GetComponent<UiImage> ();
				print (startSize.x);
				img.rectTransform.sizeDelta = new Vector2 (startSize.x, startSize.y);
				img.rectTransform.position = new Vector2 (startPos.x, startPos.y);
				firstpress = true;
			}


	}
}
