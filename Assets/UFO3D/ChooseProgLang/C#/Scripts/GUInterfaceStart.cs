using UnityEngine;

/// <summary>
/// This script displays a title screen, some description, and a start button.
/// </summary>
public class GUInterfaceStart : MonoBehaviour
{
	public GUISkin mySkin; //The GUISkin we'll use, which holds info about the fonts and styles in the interface
	public string DescriptionText; //the description text

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// </summary>
	void OnGUI()
	{
		//Set the general GUI style we're going to use
		GUI.skin = mySkin;

		//Description text
		GUI.Box(new Rect(0, Screen.height * 0.6f, Screen.width, Screen.height * 0.3f), DescriptionText);

		// The start button
		if (GUI.Button(new Rect(0, Screen.height * 0.9f, Screen.width, Screen.height * 0.1f), "Click to Start"))
		{
			Application.LoadLevel("gameCS"); //load the game level
		}
	}
}

