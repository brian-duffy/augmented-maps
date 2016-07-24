using UnityEngine;
using System.Collections;

public class GeologySelect : MonoBehaviour {
	public DynamicText rockInfoText;
	public DynamicHeader rockInfoHeader;
	public GameObject AgglomerateButton;
	public GameObject AndesiteButton;
	public GameObject BasaltButton;
	public GameObject DaciteButton;
	public GameObject GravelButton;
	public GameObject TuffButton;
	public GameObject DiamictonButton;
	public GameObject SandGravelButton;
	public GameObject PeatButton;
	public GameObject RhyoliteButton;
	public GameObject ClaySiltSandButton;
	public GameObject MicrodioriteButton;
	public GameObject allGeolTypes;
	public weather weatherScript;
	public WalkWay walkwayscript;
	public GameObject GeologyButton;
	public GameObject GeologyButtonInactive;
	//public GameObject GeologyButton;
	internal bool geologyButtonSelected = false;
	internal int menu = 0;
	internal int i;
	internal int rockCount;
	public GameObject[] rocks;
	public int x;
	internal bool allowRender = false;

	void Start(){
		rockCount = transform.childCount;
		Debug.Log (rockCount);

	}

	public void enableRender(){

		rocks = new GameObject[transform.childCount];
		
		foreach(Transform child in transform){
			
			rocks[i++] = child.gameObject;
			child.gameObject.SetActive(true);
			child.renderer.enabled = false;
			}
	}


	public void GeologyButtonPress(){

		if (menu == 1) {
			disableRocks ();
			geologyButtonSelected = false;
			menu = 0;
			GeologyButton.SetActive(false);
			GeologyButtonInactive.SetActive(true);
		}

		else{
			weatherScript.weatherButtonActive.SetActive(false);
			weatherScript.weatherButtonInactive.SetActive(true);
			GeologyButtonInactive.SetActive(false);
			GeologyButton.SetActive(true);

			geologyButtonSelected = true;
			//allGeolTypes.SetActive (true);
			rockInfoText.textUpdate.alignment = TextAnchor.MiddleCenter;
			rockInfoHeader.Header.text = ("");
			rockInfoText.textUpdate.text = ("Press on any area of the map to see the rock type");
			menu = menu + 1;
		}

		weatherScript.disableCurrentObjects();
		weatherScript.miniPanel.SetActive (false);
		weatherScript.x = 0;

		walkwayscript.PauseButtonPressed ();
		}

	public void disableRocks(){
		//function to disable all current buttons and position text and headers correctly
		//put all buttons in new array
		GameObject[] buttons= new GameObject[] {AgglomerateButton, AndesiteButton, 
			BasaltButton, DaciteButton, GravelButton, TuffButton, DiamictonButton,
			SandGravelButton, PeatButton, RhyoliteButton, ClaySiltSandButton, MicrodioriteButton};
		//disable each button in the array
		foreach (GameObject button in buttons){
			button.SetActive(false);
		}
		//disable all rock mesh renders
		foreach(Transform child in transform){
			child.renderer.enabled = false;
			child.transform.renderer.enabled = false;
			//child.gameObject.SetActive(false);
		}
		//Align text to make room for rock image
		rockInfoText.textUpdate.alignment = TextAnchor.MiddleLeft;
		//Resize box of text for rock information
		rockInfoText.textUpdate.rectTransform.sizeDelta = new Vector2 (500, 240);
		//Move rock information box -100 pixels to the left to make room for rock image
		rockInfoText.textUpdate.rectTransform.anchoredPosition =  new Vector2(-100, 3);
		rockInfoText.textUpdate.text = ("");
		rockInfoHeader.Header.text = ("");
	}

	public void tuffPress(string name, GameObject tuff){
		disableRocks ();
		tuff.renderer.enabled = !tuff.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("A volcanic rock that may be considered a quartz-bearing variety of andesite."); 
		TuffButton.SetActive (true);
	}

	public void dacitePress(string name, GameObject dacite){
		disableRocks ();
		dacite.renderer.enabled = !dacite.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("A volcanic rock that may be considered a quartz-bearing variety of andesite."); 
		DaciteButton.SetActive (true);
	}

	public void diamictonPress(string name, GameObject diamicton){
		disableRocks ();
		diamicton.transform.renderer.enabled = !diamicton.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("Composed of a wide range of clast sizes; includes varying proportions of boulders-cobbles-sand-silt-clay; with no genetic connotation."); 
		DiamictonButton.SetActive (true);	
		}


	public void andesitePress(string name, GameObject andesite){
		disableRocks ();
		andesite.renderer.enabled = !andesite.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("An extrusive igneous, volcanic rock, of " +
		                                "intermediate composition, with aphanitic to porphyritic texture. "); 
		AndesiteButton.SetActive (true);
	}


	public void basaltPress(string name, GameObject basalt){
		disableRocks ();
		basalt.renderer.enabled = !basalt.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("An extrusive igneous (volcanic) rock that is low in silica content," +
			"dark in colour, and comparatively rich in iron and magnesium."); 
		BasaltButton.SetActive (true);
	}

	                    
	public void gravelPress(string name, GameObject gravel){
		disableRocks ();
		gravel.renderer.enabled = !gravel.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("An aggregate of more or less rounded rock fragments coarser than sand."); 
		GravelButton.SetActive (true);
	}

	public void agglomeratePress(string name, GameObject agglomerate){
		disableRocks ();
		agglomerate.renderer.enabled = !agglomerate.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("Large, coarse, rock fragments " +
		                                "associated with lava flow that are ejected during explosive volcanic eruptions."); 
		AgglomerateButton.SetActive (true);
	}


	public void sandGravelPress(string name, GameObject sandGravel){
		disableRocks ();
		sandGravel.renderer.enabled = !sandGravel.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("Whether found on beaches or in rivers and streams, it is mostly quartz grains." +
		                                " The silica itself is needed to make products such as glass."); 
		SandGravelButton.SetActive (true);

	}

	public void peatPress(string name, GameObject peat){
		disableRocks ();
		peat.renderer.enabled = !peat.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("Peat (turf) is an accumulation of partially decayed vegetation or organic matter that is unique to natural " +
			"areas called peatlands or mires."); 
		PeatButton.SetActive (true);
	}

	public void rhyolitePress(string name, GameObject rhyolite){
		disableRocks ();
		rhyolite.renderer.enabled = !rhyolite.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("An extrusive igneous rock that is the volcanic equivalent of granite. " +
		                                "Rhyolites are known from all parts of the Earth and from all geologic ages."); 
		RhyoliteButton.SetActive (true);
	}

	public void claySiltSandPress(string name, GameObject claySiltSand){
		disableRocks ();
		claySiltSand.renderer.enabled = !claySiltSand.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("Sand, being the largest size of particles, feels gritty. " +
		                                "Silt, being moderate in size, has a smooth or floury texture. Clay, the smallest size, feels sticky."); 
		ClaySiltSandButton.SetActive (true);
	}

	public void microdioritePress(string name, GameObject microdiorite){
		disableRocks ();
		microdiorite.renderer.enabled = !microdiorite.renderer.enabled;
		rockInfoHeader.Header.text = ("Rocktype: " + name);
		rockInfoText.textUpdate.text = ("Microdiorite is a rare medium-grained intrusive igneous rock, containing crystals smaller than grains of rice."); 
		MicrodioriteButton.SetActive (true);
	}
}
