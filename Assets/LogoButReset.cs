using UnityEngine;
using System.Collections;

public class LogoButReset : MonoBehaviour {
	
	[SerializeField] public Button Button1 = null; // assign in the editor
	[SerializeField] public Button Button2 = null; // assign in the editor
	
	
	void Start() {
	//	Button1.onClick.AddListener(() => { LogoButtonReset();});
//		Button2.onClick.AddListener(() => { PanelButtonInc();});
	}
	
	public void PanelButtonInc() {
		
		SetButInc.nextNum ++;
		
	}
	
	public void LogoButtonReset() {
		
		SetButInc.nextNum=0;
		
	}

	void OnGUI(){
	//	Button1 = GUI.Toggle (new Rect (Screen.width - 2050, Screen.height - 290, 250, 250));

		}

}

