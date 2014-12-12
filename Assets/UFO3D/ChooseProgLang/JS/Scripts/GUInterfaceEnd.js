//This script displays a score and a restart button
var mySkin : GUISkin; //The GUISkin we'll use, which holds info about the fonts and styles in the interface
private var ScoreText:int; //the description text

function Start()
{
	ScoreText = GameObject.Find("UFO").GetComponent("UFOcontrol").Score; //set the score based on the UFO object carried over from the previous game scene
	
	Destroy(GameObject.Find("UFO")); //destroy the UFO object carried over from the previous game scene
}

//Here we set an animate the GUI elements
function OnGUI ()
{	
	//Set the general GUI style we're going to use
	GUI.skin = mySkin;
	
	//Score text
	GUI.Box ( Rect ( 0 , Screen.height * 0.8, Screen.width, Screen.height * 0.1), ScoreText.ToString() + " Cows collected!");

	// The restart button
	if (GUI.Button (Rect ( 0 , Screen.height * 0.9, Screen.width, Screen.height * 0.1), "Click to Restart")) 
	{
		Application.LoadLevel ("startJS"); //load the game level
	}
}