using UnityEngine;
using System.Collections;

public class SetButInc : MonoBehaviour {
	
	public static int nextNum;
	
	void Awake() {
		
		nextNum=0;
		Debug.Log (nextNum);
	}
	
}