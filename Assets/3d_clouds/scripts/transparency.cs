using UnityEngine;
using System.Collections;

public class transparency : MonoBehaviour {
	private Transform cl1;
	private Transform cl2;
	private Transform cl3;
	private Transform cl4;
	private Transform cl5;
	public static float darkness=0f;
	public static float density=1f;
	// Use this for initialization
	void Start () {
	
		
	}
	
	void OnGUI(){
		GUI.Label(new Rect(300,25,200,20),"Clouds Density:");
		density = GUI.HorizontalSlider(new Rect(300,45,130,20),density,0.5f,1.5f);
	GUI.Label(new Rect(600,25,200,20),"Clouds Darkness:");
		darkness = GUI.HorizontalSlider(new Rect(600,45,130,20),darkness,0f,.4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
