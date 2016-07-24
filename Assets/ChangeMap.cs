using UnityEngine;
using System.Collections;

public class ChangeMap : MonoBehaviour {
	/// <summary>
	/// Class to change the map displayed on each terrain object 
	/// </summary>

	public int mapNum = 1;
	public GameObject sunlight;
	public GameObject bingMap;
	public GameObject localMap;
	public GameObject _50kMap;
	public GameObject arrow;
	public Texture2D lambert2;
	public Texture2D lambert1;
	public Texture2D lambert3;

	public void changeMapSequence(int i){
		mapNum = mapNum + i;
		if (mapNum == 0){
			disableAll ();
			arrow.renderer.material.mainTexture = lambert1;
			bingMap.SetActive(true);
			sunlight.light.intensity = 0.6f;
			}

		else if (mapNum == 1) {
			sunlight.light.intensity = 0.2f;
			disableAll ();
			localMap.SetActive(true);
			arrow.renderer.material.mainTexture = lambert2;
			}

		else if (mapNum == 2) {
			disableAll ();
			_50kMap.SetActive(true);
			arrow.renderer.material.mainTexture = lambert3;
			sunlight.light.intensity = 0.2f;
		}
		// Catch the int incase it goes below threshold of maps
		if (mapNum == -1){
			mapNum = 0;
		}


		if (mapNum == 3){
			mapNum = 2;
		}
	}

	private void disableAll(){
		localMap.SetActive (false);
		bingMap.SetActive (false);
		_50kMap.SetActive (false);
		}

}

