using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicHeader : MonoBehaviour {
	internal Text Header;
	// Use this for initialization
	void Start () {
		Header = GetComponent<Text> ();
		
	}
}
