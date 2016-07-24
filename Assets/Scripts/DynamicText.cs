using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour {

	internal Text textUpdate;
	// Use this for initialization
	void Start () {
		textUpdate = GetComponent<Text>();
	}
}