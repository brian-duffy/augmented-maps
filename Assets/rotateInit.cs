using UnityEngine;
using System.Collections;

public class rotateInit : MonoBehaviour {
	private int rotSpeed = 120;
	private Vector3 initPosPink;
	private Vector3 initPosBlue;
	private Vector3 scale;
	private Vector3 initScale;
	public GameObject Pink;
	public GameObject Blue;
	private int initPosPinkx;
	private int currPosPinkx;

	private bool pinktoBlue = false;
	private bool pinktoOrg = false;

	internal bool imgSelected = false;

	// Use this for initialization
	void Start () {
		initPosBlue = Blue.transform.position;
		initPosPink = Pink.transform.position;
		initPosPinkx = (int)initPosPink.x;
		initScale = Blue.transform.localScale;
		scale = new Vector3(30,30,30);
	}
	
	// Update is called once per frame
	void Update () {
		if (imgSelected) {
						rightToLeft ();
						leftToRight ();
				}
		}

	void rightToLeft(){
		int currPosPinkx = (int)Pink.transform.position.x; 
		
		if (pinktoBlue == false) {
			Pink.transform.Translate (Vector3.right * rotSpeed * Time.deltaTime);
			Blue.transform.Translate (Vector3.left * rotSpeed * Time.deltaTime);
			Blue.transform.localScale = Vector3.Lerp(Blue.transform.localScale, scale, Time.deltaTime);
			Pink.transform.localScale = Vector3.Lerp(Pink.transform.localScale, initScale, Time.deltaTime);
		}
		
		if (currPosPinkx >= (initPosPinkx + 80)){
			pinktoBlue = true;
		}
	}

	void leftToRight(){
		int currPosPinkx = (int)Pink.transform.position.x; 

		if (pinktoBlue) {
		
			Pink.transform.Translate (Vector3.left * rotSpeed * Time.deltaTime);
			Blue.transform.Translate (Vector3.right * rotSpeed * Time.deltaTime);
			Blue.transform.localScale = Vector3.Lerp(Blue.transform.localScale, initScale, Time.deltaTime);
			Pink.transform.localScale = Vector3.Lerp(Pink.transform.localScale, scale, Time.deltaTime);
			}

		if (currPosPinkx <= (initPosPinkx)) {

			pinktoBlue = false;
			}
	}

	public void resetMarkers(){
		Blue.transform.position = initPosBlue;
		Pink.transform.position = initPosPink;
		Pink.transform.localScale = initScale;
		Blue.transform.localScale = initScale;
	
		}
}
