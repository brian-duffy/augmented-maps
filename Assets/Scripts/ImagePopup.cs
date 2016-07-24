using UnityEngine;
using System.Collections;

public class ImagePopup : MonoBehaviour {

	public WalkWay walkwayscript;
	public GameObject pointOneImg;
	public GameObject pointTwoImg;
	public GameObject pointThreeImg;
	public GameObject pointFourImg;
	public GameObject arrowOne;
	public GameObject arrowTwo;
	public GameObject arrowThree;
	public GameObject arrowFour;
	public GameObject SphereOne;
	public GameObject SphereTwo;
	internal bool imageGUI = false;
	public GUISkin ImageGUIskin;
	internal bool trackerFound = false;
	public GameObject imageButtonActive;
	public GameObject imageButtonInactive;

	internal bool pointOneSelected = false;
	internal bool pointTwoSelected = false;
	internal bool pointThreeSelected = false;
	internal bool pointFourSelected = false;
	internal int imageMenu = 0;

	// Use this for initialization
	void Start () {
		disableAll ();
		}
	// Update is called once per frame
	void Update () {
		if (imageGUI) {
			ImageSelection ();
			tracker ();
				}
	}

	public void disableAll(){

		GameObject[] imageObjects = new GameObject[] {pointOneImg, pointTwoImg,
			pointThreeImg, pointFourImg, SphereOne, SphereTwo,arrowOne,
			arrowTwo, arrowThree, arrowFour};

		foreach (GameObject imageobject in imageObjects) {
			imageobject.transform.renderer.enabled = false;
			imageobject.SetActive(false);
				}
		SphereOne.SetActive (false);
		SphereTwo.SetActive (false);
		}

	public void tracker() {

		if (walkwayscript.WPindexPointer == 3) {
			pointOneSelected = true;
			pointFourSelected = false;
			arrowFour.SetActive(false);
			arrowOne.SetActive(true);
			arrowOne.renderer.enabled = true;
				}
		if (walkwayscript.WPindexPointer == 12) {
			pointOneSelected = false;
			arrowOne.SetActive(false);
			arrowTwo.SetActive(true);
			arrowTwo.renderer.enabled = true;
			pointTwoSelected = true;
				}
		if (walkwayscript.WPindexPointer == 17) {
			arrowTwo.SetActive(false);
			pointTwoSelected = false;
			pointThreeSelected = true;
			arrowThree.SetActive(true);
			arrowThree.renderer.enabled = true;
				}
		if (walkwayscript.WPindexPointer == 25) {
			arrowThree.SetActive(false);
			pointFourSelected = true;
			arrowFour.SetActive(true);
			arrowFour.renderer.enabled = true;
			pointThreeSelected = false;
				}


		}

	void ImageSelection()
	{
		pointOneImg.transform.renderer.enabled = false;
		pointTwoImg.transform.renderer.enabled = false;
		pointThreeImg.transform.renderer.enabled = false;
		pointFourImg.transform.renderer.enabled = false;

		if (pointOneSelected == true) {
			pointOneImg.SetActive(true);
			pointOneImg.transform.renderer.enabled = true;
				}

		if (pointTwoSelected == true) {
			pointTwoImg.SetActive(true);
			pointTwoImg.transform.renderer.enabled = true;
				}
				

		if (pointThreeSelected == true) {
			pointThreeImg.SetActive(true);
			pointThreeImg.transform.renderer.enabled = true;
				}

		if (pointFourSelected == true) {
			pointFourImg.SetActive(true);
			pointFourImg.transform.renderer.enabled = true;
				}

	}
	public void imageButton(){

		if (imageMenu == 1) {
			imageMenu = 0;
			imageGUI = false;
			disableAll ();
			imageButtonActive.SetActive(false);
			imageButtonInactive.SetActive(true);
			} 
		else {
			imageGUI = true;
			imageButtonInactive.SetActive(false);
			imageButtonActive.SetActive(true);
			SphereOne.SetActive (true);
			SphereOne.renderer.enabled = true;
			SphereTwo.SetActive (true);
			SphereTwo.renderer.enabled = true;
			imageMenu = imageMenu + 1;
			}
		}
}
