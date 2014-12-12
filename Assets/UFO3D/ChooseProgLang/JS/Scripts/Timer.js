//This is a timer script. It displays the time in the corner of the screen, 
//and goes to the next level when time runs out.

var Timer:int = 60; //Total time
var mySkin : GUISkin; //The GUISkin we'll use, which holds info about the fonts and styles in the interface
var Player:Transform; //the player object

function OnGUI()
{
	//Set the general GUI style we're going to use
	GUI.skin = mySkin;
	
	//the timer
	GUI.Label ( Rect ( Screen.width - 42 , 0, 42, 38), Mathf.Round(Timer - Time.timeSinceLevelLoad).ToString() );
}

function Update()
{
	 //if time runs out. go to next level, making sure the player object (which contains the score) is not destroyed ( carries over to the next scene)
	 if ( Time.timeSinceLevelLoad >= Timer )
	 {
		//print("level end");
		
		//make the total score object indestructible, so we can use it in the next scene
		DontDestroyOnLoad(Player);
		
		//load the last scene
		Application.LoadLevel ("endJS"); //load the game level
	 }
}