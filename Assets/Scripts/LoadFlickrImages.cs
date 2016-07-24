using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UiImage = UnityEngine.UI.Image;

using SimpleJSON;
public class LoadFlickrImages : MonoBehaviour {
	//define longitude and width of map
	//
	// Note to self : IF using this script on a terrain which is NOT located
	// at (0,0,0), calculate distances between each new location.	//
	private float mapWidth = 3060;
	private float leftLong = -3.24254f;
	private float rightLong = -3.1918f;
	//define height and latitude values of map
	private float mapHeight = 2406;
	private float bottomLat = 55.87510f;
	private float topLat = 55.898397f;
	//parameters needed to calculate position
	private float changeinLat;
	private float changeinLong;
	private float latPerPixel;
	private float longPerPixel;
	//bool to check if JSON parsing is complete
	private bool parseComplete = false;
	private bool textureLoadComplete = false;
	private bool loadImage = false;
	internal bool imageLoaded;
	private bool done;
	private bool oneRunThroughOnly = true;
	// clone objects to alter without changing original
	private float[] longsClone;
	private float[] latsClone;
	private string[] imageClone;
	private Texture2D[] texturesClone;
	private GameObject[] imgObjClone;
	internal int selected;

	public string flickrUsername;

	//get lat and long positions;
	public Terrain[] terrains;
	public Transform prefab;
	public GameObject image;
	private GameObject[] images;
	private GameObject[] allimg;
	public GameObject flickr;
	public GameObject loadingIcon;

	private Sprite sprite;

	public Camera mainCamera;
	public GameObject imageGUI;

	//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	RaycastHit hit = new RaycastHit();

	//private int selected;
	void Start(){
		getPerPixelValues ();
		mainCamera = Camera.main;
	}

	private void getPerPixelValues(){
		changeinLat = (topLat - (bottomLat));
		changeinLong = ((-leftLong) -(-rightLong));
		latPerPixel = (changeinLat) / mapHeight;
		longPerPixel = (changeinLong) / mapWidth;
	}

	public void prepJSON(){
		string url = "http://www.brianduffy.me/scripts/flickr/flickrquery.php";
		WWW www = new WWW (url);
		StartCoroutine (getJSONString (www));
	}

	IEnumerator getJSONString(WWW www){
		//get the string from the URL
		yield return www;	
		string response = www.text;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: ");
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
		parseJSON (response);
	}

	public void parseJSON(string JSONstring){
		
		var JSONparser = JSON.Parse (JSONstring);
		string[] imageURLs = new string[JSONparser.Count];
		float[] longs = new float[JSONparser.Count];
		float[] lats = new float[JSONparser.Count];
		for (int i = 0; i < JSONparser.Count; i++) {
			imageURLs[i] = JSONparser.AsArray[i][0]["imageURL"];
			lats[i] = JSONparser.AsArray[i][1]["latitude"].AsFloat;
			longs[i] = JSONparser.AsArray[i][1]["longitude"].AsFloat;
		}
		//clone all objects so they can be accessed in other functions
		longsClone = longs;
		latsClone = lats;
		imageClone = imageURLs;
		parseComplete = true;
		//set parse complete
		// Now that parsing is complete, place the objects in the scene
		placeobjs ();
	}

	private void placeobjs(){
		
		if (parseComplete) {
			GameObject[] allimg = moveImages (latsClone, longsClone);
			StartCoroutine(loadTextures());

			//move the images to the correct position.
		}
		
	}

	public GameObject[] moveImages(float[] lats, float[] longs){
		//takes in Float ARRAYS of LAT and LONG values
		//
		// Outputs an array of GameObjects
		//
		GameObject myObject = flickr;
		//find flickr GameObject so it can be copied
		images = new GameObject[longs.Length];
		//initiate new array of images, defined by the length of long values in longs array
		for (int i = 0; i < longs.Length; i++) {
			//loop through each item of the array
			Transform[] allxyzs = new Transform[longs.Length];
			//initate new array of Transforms, defined by array length
			allxyzs[i] = getXYZ(longs[i], lats[i]);
			//for each value in the long string, get XYZ values and attach to Transform array
			images[i] = Instantiate(myObject, new Vector3(allxyzs[i].transform.position.x,
			                                              allxyzs[i].transform.position.y,
			                                              allxyzs[i].transform.position.z), Quaternion.identity) as GameObject;
			//instantiate new objects for each item in the array
			//
			// position the object in Unity coordinates
			// rename the Gameobject with index, so it can be accessed by RayCast function.
			images[i].name = "FlickrLogo" +i;
			images[i].SetActive(true);
			foreach (Transform child in images[i].transform){
				child.renderer.enabled = true;
			}
		}

		imgObjClone = images;
		return imgObjClone;
	}

	public Transform getXYZ(float longToPlace, float latToPlace){
		//
		// Transform function to accept LONG and LAT floats, and return their respected
		// Unity Coordinates, including height of the nearest Terrain
		//
		//works if bottom left of map is positioned at (0,0,0)
		float changeFromLong = ((longToPlace) - (leftLong));
		//calculate change in long so it can be compared to change in pixel value
		// Divide the change in values to the per pixel values to determine Unity coordinates
		float xpos = changeFromLong / longPerPixel;
		//repeat for latitude
		float changefromLat = ((latToPlace) - (bottomLat));
		float ypos = changefromLat / latPerPixel;
		//move sphere to the correct position along X and Z axis
		Vector3 position = new Vector3 (xpos,0, ypos);
		GameObject newobj = new GameObject ();
		newobj.transform.position = position;
		//Determine nearest Terrain from the current object
		Terrain nearest = closestTerrain (terrains, newobj);
		// copy transform position 
		Vector3 pos = newobj.transform.position;
		Transform xy = newobj.transform;
		//set height value of pos to the height value measured at the object's position
		pos.y = nearest.SampleHeight (xy.position);
		//Increase height so that it can be located just above the terrain
		pos.y = pos.y + 50f;
		//add height value to the previously calulated 2D position.
		newobj.transform.position = pos;
		Transform newT = newobj.transform;
		//Destroy the object that was created to copy over the x and z values
		Destroy (newobj);
		//print (newT.position.x);
		return newT;
	}
	

	
	
	Terrain closestTerrain (Terrain[] terrains, GameObject imageMarker)
	{
		//get closest terrains
		Terrain nearestTerrain = null;
		//assign nearest Terrain as null
		float closestDistanceSqr = Mathf.Infinity;
		//use Square root for better efficiency in search for nearest object
		Vector3 currentPosition = imageMarker.transform.position;
		//store current position of object
		foreach(Terrain eachTerrain in terrains)
			//loop through each of the terrains
		{
			Vector3 directionToTarget = eachTerrain.transform.position - currentPosition;
			float TerrainDistSqrd = directionToTarget.sqrMagnitude;
			//Use Squarert to target
			if(TerrainDistSqrd < closestDistanceSqr)
			{
				//determine closest Terrain
				closestDistanceSqr = TerrainDistSqrd;
				nearestTerrain = eachTerrain;
			}
		}
		return nearestTerrain;
	}

	private IEnumerator  loadTextures(){
	
		Texture2D[] allimgTextures = new Texture2D[imageClone.Length];
		
		for (int i = 0; i < imageClone.Length; i++) {
			
			string url = imageClone[i];

			WWW www = new WWW (url);
			yield return www;
			allimgTextures[i] = new Texture2D (www.texture.width, www.texture.height, TextureFormat.DXT1, false);
			www.LoadImageIntoTexture(allimgTextures[i]);
		}
		texturesClone = allimgTextures;
		textureLoadComplete = true;


		loadingIcon.SetActive(false);
		click ();
	}
	
	public void click (){
		if (oneRunThroughOnly) {
			Debug.Log("ONCE");
			loadingIcon.SetActive(true);
			prepJSON ();
			oneRunThroughOnly = false;
			} 
		else if (oneRunThroughOnly == false) {
			done = true;
			loadImage = true;
		}
	}


	void Update(){
		if (done && parseComplete && textureLoadComplete) {
			//only update if everything is completed
			if (Input.touchCount > 0){
				Vector2 touchPosition = Input.GetTouch(0).position;

				Ray ray = mainCamera.ScreenPointToRay (touchPosition);
				//Ray rayMouse = mainCamera.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit = new RaycastHit ();
				if (Physics.Raycast (ray, out hit)) {
				//if an object has been hit
					if (Input.GetMouseButtonDown (0)) {
						for (int i = 0; i < imageClone.Length; i++) {
						//loop through all available flickr objects
							if (hit.collider.gameObject.name == "FlickrLogo" + i) {
								//if the object pressed has the specified gameobject name
								imageSelected(i);
							}
						}
					}
				}
			}
		}
	}
	

	void OnGUI(){
		if (loadImage) {
			getSetSprite(texturesClone[selected], imageGUI);
			imgObjClone[selected].GetComponent<rotateInit>().imgSelected = true;
			//get sprite from the texture, needed to load for the image
			imageGUI.SetActive(true);
			imageLoaded = true;
			}
		loadImage = false;
	}

	private void getSetSprite (Texture2D tex, GameObject obj){
		//function to take texture and apply it to the obj passed
		int width = tex.width;
		int height = tex.height;
		Sprite sprite = Sprite.Create (tex, new Rect (0f, 0f, width, height), new Vector2 (0.5f, 0.5f), 128f);
		obj.GetComponent<UiImage> ().sprite = sprite;
	}	

	private void imageSelected(int selection){
		selected = selection;
	}


	public void changeImage(){
		//
		// Important to distinguish between short press and long press
		// so that the image wasn't accidentally pressed after the long button
		//
		int nextImage = 1;

		if (imageGUI.GetComponent<imagePressed>().shortpress){
			//if the shortbutton press has been pressed, do the following
			imgObjClone[selected].GetComponent<rotateInit>().imgSelected = false;
			imgObjClone [selected].GetComponent<rotateInit> ().resetMarkers ();
			selected = selected + nextImage;
			loadImage = true;
		if (selected >= imgObjClone.Length) {
			selected = 0;
			}
		}
	
		else
			imageGUI.GetComponent<imagePressed>().shortpress = true;
	}


	public void flickrUserLoad(string flickrUser){

		print ("IN FLICKR SCRIPT: " + flickrUser);

	}


}


