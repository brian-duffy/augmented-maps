using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;

public class weather : MonoBehaviour {
	/// <summary>
	/// Class to dictate which weather objects will be enabled dependent on weather script.
	/// </summary>
	private bool mostlyCloudyCheck = false;
	private bool partlyCloudyCheck = false;
	private bool overcastCheck = false;
	private bool rainCheck = false;
	private bool rainHeavyCheck = false;
	public GameObject mostlyCloudy;
	public GameObject partlyCloudy;
	public GameObject overcast;
	public GameObject rainMaker;
	public GameObject rainHeavy;
	public GameObject sunlight;
	public GameObject miniPanel;
	public GameObject weatherButtonActive;
	public GameObject weatherButtonInactive;
	private string weatherForecast;
	private string detailedWeatherForecast;
	public bool trackerFound = false;
	internal int x = 0;
	private int i = -1;
	internal bool showCurrHeader;
	public DynamicText updateWeatherGUI;
	public DynamicHeader updateWeatherHeader;
	private string todaysWeather;
	private string todaysWeatherConstant;

	System.Text.StringBuilder sb = new System.Text.StringBuilder ();
	System.Text.StringBuilder currCondition = new System.Text.StringBuilder ();
	internal string currTempString;
	internal string currConditionString;
	string currWeather;
	ArrayList strings = new ArrayList();
	
	ArrayList weatherPrediction = new ArrayList();
	ArrayList daysPrediction = new ArrayList();
	ArrayList conditionPrediction = new ArrayList();
	internal bool showCurrweather = false;
	internal string weatherstring;
	public GeologySelect geologyScript;
	public GameObject Geology;


	//Begin by disabling all current weather objects on initiation
	void Start(){
		disableCurrentObjects ();
		weatherfunc ();
		}

	//Enable objects which have the correct weather info
	/// <summary>
	/// USE UPDATE SPARINGLY !!!!	/// </summary>
	void Update(){
		}
	public void weatherfunc(){
		string url = "http://brianduffy.me/scripts/weather.php";
		WWW www = new WWW (url);
		StartCoroutine (registerFunc (www));
		Debug.Log ("Weather Function Initiated");
		}

	IEnumerator registerFunc(WWW www){
		//get the string from the URL
		yield return www;			
		//Split the string up by "->" and assign the range to array strings
		strings.AddRange (Regex.Split (www.text, "->"));

		//unpacking the php string - each forecast lasts 10 days.
		for (int i = 0; i < 10; i++)
		{
			string days = strings[i].ToString();
			daysPrediction.Add(strings[i]);
			//add each day to string

		}
		//unpacking each days forecast
		for (int i = 10; i <20; i++){
			conditionPrediction.Add(strings[i]);
		}
		//unpacking low temperatures
		for (int i = 20; i < 30; i++) {
			string low_temp = strings[i].ToString();
				}
		//unpacking high temperatures
		for (int i = 30; i < 40; i++) {
			string high_temp = strings [i].ToString ();
				}
		//unpacking each days weather prediction
		for (int i = 42; i <62; i += 2) {
			weatherPrediction.Add(strings[i]); 
		}
	
		//begin calling functions dependent on weather info


		currConditionString = "Current Condition is: ";
		currCondition.Append (currConditionString);
		currCondition.Append (strings[41].ToString());
		todaysWeather = strings [41].ToString ();

		todaysWeatherConstant = strings [41].ToString ();
		print ("TODAYS WEATHER CONSTANT IS EQUAL TO " + todaysWeatherConstant);
		currTempString = ", with a temperature of  ";
		currCondition.Append (currTempString);
		currCondition.Append (strings [40].ToString ());
		currCondition.Append ("°C.");

		weatherstring = currCondition.ToString ();
		}
		

	public void disableCurrentObjects (){
		/// function to disable all current weather patterns on initiation.
		/// 
		/// 
		GameObject[] weatherobjects = new GameObject[] {partlyCloudy, mostlyCloudy, overcast, rainMaker, rainHeavy};
		foreach (GameObject weatherobject in weatherobjects) {
			weatherobject.SetActive(false);
				}
		rainCheck = false;
		rainHeavyCheck = false;
		mostlyCloudyCheck = false;
		partlyCloudyCheck = false;
		overcastCheck = false;
		rainHeavyCheck = false;
		sunlight.light.intensity = 0.6f;

		}
	public void enableCurrentObjects(){
		//enable the relevant weather objects if the weather is correct

		sunlight.light.intensity = 0.6f;
		if (mostlyCloudyCheck) {
			mostlyCloudy.SetActive (true);
			mostlyCloudy.renderer.enabled = true;
			sunlight.light.intensity = 0.4f;

			if (rainCheck) {
				rainMaker.SetActive (true);
				rainMaker.renderer.enabled = true;
				sunlight.light.intensity = 0.4f;
			}
		}
		if (partlyCloudyCheck) {
			partlyCloudy.SetActive (true);
			partlyCloudy.renderer.enabled = true;
			sunlight.light.intensity = 0.5f;
		}
		if (overcastCheck) {
			overcast.SetActive (true);
			overcast.renderer.enabled = true;
			if (rainHeavyCheck) {
				rainHeavy.SetActive (true);
				rainHeavy.renderer.enabled = true;
				sunlight.light.intensity = 0.2f;
				}
		}
	}
	public void weatherButtonPressed(){
		geologyScript.disableRocks ();


		if (x == 1) {
			miniPanel.SetActive(false);
			weatherButtonInactive.SetActive (true);
			weatherButtonActive.SetActive (false);
			geologyScript.GeologyButtonInactive.SetActive(true);
			Debug.Log("x = 1");
			x = 0;
			updateWeatherHeader.Header.text = "";
			geologyScript.disableRocks(); 
			updateWeatherGUI.textUpdate.text = "";
			disableCurrentObjects();
			Geology.SetActive(true);
			todaysWeather = "";
			geologyScript.menu = 0;
			}

		else if (x == 0) {
			weatherButtonInactive.SetActive (false);
			weatherButtonActive.SetActive (true);
			geologyScript.GeologyButton.SetActive(false);
			geologyScript.GeologyButtonInactive.SetActive(true);

			miniPanel.SetActive (true);
			geologyScript.disableRocks();
			Geology.SetActive(false);
			updateWeatherHeader.Header.text = "";
			updateWeatherGUI.textUpdate.text = "";
			updateWeatherGUI.textUpdate.alignment = TextAnchor.MiddleCenter;
			updateWeatherGUI.textUpdate.rectTransform.sizeDelta = new Vector2 (700, 240);
			updateWeatherGUI.textUpdate.rectTransform.anchoredPosition = new Vector2 (1, 3);
			updateWeatherGUI.textUpdate.text = currCondition.ToString ();
			updateWeatherHeader.Header.text = "Current Weather";
			weatherForecast = "";
			showCurrweather = true;
			showCurrHeader = true;
			todaysWeather = todaysWeatherConstant;
			enableCurrentObjects ();
			Debug.Log ("x = 0");
			x = x + 1;
			geologyScript.menu = 0;
			}
			i = -1;

		loadWeatherModels ();	
		}
	

	public void nextDayWeather(){
		geologyScript.disableRocks ();
		updateWeatherGUI.textUpdate.alignment = TextAnchor.MiddleCenter;
		updateWeatherGUI.textUpdate.rectTransform.sizeDelta = new Vector2 (700, 240);
		updateWeatherGUI.textUpdate.rectTransform.anchoredPosition = new Vector2 (1, 3);
		i = i + 1;
		todaysWeather  = ""; 
		if (i == 10) {
			i = 9;
			Debug.Log ("Cant go above 10");
		}


		else{
		disableCurrentObjects();
		print (i);
		strings [41]= "";
		displayForecast ();
		Debug.Log ("Next Day");
			}
		}

	public void prevDayWeather (){
		todaysWeather  = ""; 
		i = i - 1;
		if (i == -1) {
			i = -1;
			disableCurrentObjects();
			weatherButtonPressed();

			Debug.Log("Cant go below -1");
		}
		else{
		print (i);
		if (i >= 0){
			disableCurrentObjects();
			displayForecast ();
			strings [41]= "";
			}
			}
		}

	private void displayForecast(){

		updateWeatherHeader.Header.text = "";
		updateWeatherGUI.textUpdate.text = "";

		string detailedWeatherForecast = weatherPrediction[i] as string;
		print (detailedWeatherForecast);
		
		string dayvalue = daysPrediction [i] as string;
		print (dayvalue);
		
		weatherForecast = conditionPrediction [i] as string;
		print (weatherForecast);
		
		updateWeatherGUI.textUpdate.text = detailedWeatherForecast;
		updateWeatherHeader.Header.text = "Showing Weather Forecast for " + dayvalue;
	
		loadWeatherModels ();
	}

private void loadWeatherModels(){

		print ("LOAD CURRENT WEATHER MODULES HERE");

		if (todaysWeather  == "Clear" | weatherForecast == "Clear") {
				Debug.Log ("Weather is  Clear");
				}
			
		if (todaysWeather  == "Partly Cloudy" | weatherForecast == "Partly Cloudy") {
				partlyCloudyCheck = true;
				Debug.Log ("Weather is Partly Cloudy");
				}
			
		if (todaysWeather  == "Scattered Clouds" | weatherForecast == "Scattered Clouds") {
				partlyCloudyCheck = true;
				print ("reached in here");
				print (partlyCloudyCheck);
				}

		if (todaysWeather  == "Mostly Cloudy" | weatherForecast == "Mostly Cloudy") {
				mostlyCloudyCheck = true;
				Debug.Log ("Weather is  Mostly Cloudy");
				}
			
		if (todaysWeather  == "Overcast" | weatherForecast == "Overcast") {
				overcastCheck = true;
				Debug.Log ("Weather is Overcast");
				}

		if (todaysWeather  == "Chance of Rain"| todaysWeather  == "Light Rain"|
		    weatherForecast == "Chance of Rain" | weatherForecast == "Light Rain") {
				mostlyCloudyCheck = true;
				rainCheck = true;
				Debug.Log ("Weather is Chance of Rain");
				}

		if (todaysWeather == "Rain" | weatherForecast == "Rain" | todaysWeather == "Chance of a Thunderstorm" | weatherForecast == "Chance of a Thunderstorm") {
						overcastCheck = true;
						rainHeavyCheck = true;
						Debug.Log ("Weather is Rain");
				}
		enableCurrentObjects ();

		for (int rain =70; rain < 100; rain++){
			if (weatherPrediction [i].ToString ().Contains ("Chance of rain " + (rain))) {
				rainCheck = true;
				Debug.Log ("Hellotoo");
			}
		}

		enableCurrentObjects ();
		}
}
