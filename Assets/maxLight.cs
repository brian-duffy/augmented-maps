using UnityEngine;
using System.Collections;

public class maxLight : MonoBehaviour {

	public GameObject sunlight;
	public GameObject LocalMap;
	public GameObject _50kMap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//bool active = LocalMap.SetActive (true);

		if (LocalMap.activeSelf | _50kMap.activeSelf) {
			sunlight.light.intensity = 0.2f;

				}

		if (sunlight.light.intensity > 0.6f) {
			sunlight.light.intensity = 0.6f;
				}

	}
}
