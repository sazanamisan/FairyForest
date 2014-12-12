//This script displays a title screen, some description, and a start button
var mySkin : GUISkin; //The GUISkin we'll use, which holds info about the fonts and styles in the interface
var DescriptionText:String; //the description text

//Here we set an animate the GUI elements
function OnGUI ()
{	
	//Set the general GUI style we're going to use
	GUI.skin = mySkin;
	
	//Description text
	GUI.Box ( Rect ( 0 , Screen.height * 0.6, Screen.width, Screen.height * 0.3), DescriptionText );

	// The start button
	if (GUI.Button (Rect ( 0 , Screen.height * 0.9, Screen.width, Screen.height * 0.1), "Click to Start")) 
	{
		Application.LoadLevel ("gameJS"); //load the game level
	}
}