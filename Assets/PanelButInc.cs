using UnityEngine;
using System.Collections;

public class PanelButInc : MonoBehaviour {
	
	public void PanelButtonInc() {
		
		SetButInc.nextNum ++;
		Debug.Log (SetButInc.nextNum);
		
	}
}