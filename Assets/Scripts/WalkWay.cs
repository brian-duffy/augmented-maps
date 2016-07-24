using UnityEngine;
using System.Collections;

public class WalkWay : MonoBehaviour
{
	public float momentum;
	// This is as fast the object is allowed to go.
	public float topSpeed;
	// This is the speed that tells the functon "Slow()" when to stop moving the object.
	public float minSpeed;
	// This varible "currentSpeed" is the major player for dealing with velocity.
	// The "currentSpeed" is mutiplied by the variable "accel" to speed up inside the function "accell()".
	// Again, The "currentSpeed" is multiplied by the variable "inertia" to slow
	// things down inside the function "Slow()".
	internal float currSpeed;
	internal bool trackerFound = false;
	// This variable will store the "active" target object (the waypoint to move to).
	private Transform walkPoint;
	private Vector3 firstPosition;
	private Quaternion firstRotation;
	public float lessRotation;
	public bool smoothTurn = true;
	public Transform[] walkPoints;
	internal int WPindexPointer;
	private float _trailTimer = 0.1f;
	public GUISkin resetMarker;
	public GameObject playButton;
	public GameObject pauseButton;
	internal bool playButtonBool = false;
	//public Custom_VirtualButton virtualButton;
	public GameObject allgeolTypes;
	internal bool walkwayButtonSelected;
	public GeologySelect geologyScript;

	//The function "Start()" is called just before anything else but only one time.

	//s_Waypoints Startwalk = new s_Waypoints();
	//Custom_VirtualButton pressbutton = new Custom_VirtualButton();


	void Start( )
	{	//Record the starting position of object
		firstPosition = transform.position;
		firstRotation = transform.rotation;
	}
	
	//The function "Update()" is called every frame. It can get slow if overused.
	void Update (){
		ResetTrail ();
		if (walkwayButtonSelected) {
						StartWalk ();
				}
		}
	// I declared "Accell()".
	public void StartWalk()
	{
						
						if (walkPoint) { //If there is a waypoint do the next "if".
								if (smoothTurn) {
										// Look at the active waypoint.
										var rotation = Quaternion.LookRotation (walkPoint.position - transform.position);
				
										// Make the rotation nice and smooth.
										// If smoothRotation is set to "On", do the rotation over time
										// with nice ease in and ease out motion.
										transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * lessRotation);
								}
						}
				
						// Now do the accelleration toward the active waypoint untill the "speedLimit" is reached
						currSpeed = currSpeed + momentum * momentum;
						transform.Translate (0, 0, Time.deltaTime * currSpeed);
		
						// When the "speedlimit" is reached or exceeded ...
						if (currSpeed >= topSpeed) {
								// ... turn off accelleration and set "currentSpeed" to be
								// exactly the "speedLimit". Without this, the "currentSpeed
								// will be slightly above "speedLimit"
								currSpeed = topSpeed;
						}
						walkPoint = walkPoints [WPindexPointer];
	

		}
	
	//The function "OnTriggerEnter" is called when a collision happens.
	void OnTriggerEnter ()
	{		
		// When the GameObject collides with the waypoint's collider,
		// change the active waypoint to the next one in the array variable "waypoints".
		WPindexPointer++;
		print (WPindexPointer);

		// When the array variable reaches the end of the list ...
		if (WPindexPointer >= walkPoints.Length)
		{
			// ... reset the active waypoint to the first object in the array variable
			// "waypoints" and start from the beginning.
			WPindexPointer = 0;
		}
	}

	public void ResetArrow(){
		//Move and rotate arrow back to first position when reset is called.
		transform.position = firstPosition;
		transform.rotation = firstRotation;
	
		if (rigidbody != null){
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
		this.gameObject.GetComponentInChildren<TrailRenderer>().time = 0f;
		WPindexPointer = 0;
		}

	//http://answers.unity3d.com/questions/41999/remove-all-particles-from-trailrenderer.html
	public void ResetTrail(){

		if(this.gameObject.GetComponentInChildren<TrailRenderer>().time == 0)
		{
			_trailTimer -= 1 * Time.deltaTime;
			if(_trailTimer <= 0)
			{
				this.gameObject.GetComponentInChildren<TrailRenderer>().time = 60f;
				_trailTimer = 0.1f;
			}
		}
	}

	public void ButtonPressed()
	{
			ResetArrow ();
	}

	
	public void PauseButtonPressed()
		{
		Time.timeScale = 0.0f;
		playButton.SetActive (true);
		pauseButton.SetActive (false);
		walkwayButtonSelected = false;
		allgeolTypes.SetActive (true);
		}


	public void PlayButtonPressed(){

		playButtonBool = true;
		playButton.SetActive (false);
		pauseButton.SetActive (true);
		geologyScript.GeologyButton.SetActive (false);
		geologyScript.GeologyButtonInactive.SetActive (true);
		walkwayButtonSelected = true;
		allgeolTypes.SetActive (false);
		geologyScript.rockInfoText.textUpdate.text = "";
		geologyScript.rockInfoHeader.Header.text = "";
		geologyScript.disableRocks ();
		geologyScript.menu = 0;

		if (Time.timeScale == 0.0) {
					Time.timeScale = 1.0f;
					Debug.Log ("Option two is false");
			}
		}

	}
