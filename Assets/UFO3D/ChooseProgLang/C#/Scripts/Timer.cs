using UnityEngine;

/// <summary>
/// This is a timer script, it displays the time in the corner of the screen and
/// goes to the next level when time runs out.
/// </summary>
public class Timer : MonoBehaviour
{
	public int TotalTime = 60; //Total time
	public GUISkin mySkin; //The GUISkin we'll use, which holds info about the fonts and styles in the interface
	public Transform Player; //the player object

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// </summary>
	void OnGUI()
	{
		//Set the general GUI style we're going to use
		GUI.skin = mySkin;

		//the timer
		GUI.Label(new Rect(Screen.width - 42, 0, 42, 38), Mathf.Round(TotalTime - Time.timeSinceLevelLoad).ToString());
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		//if time runs out. go to next level, making sure the player object (which contains the score) is not destroyed ( carries over to the next scene)
		if (Time.timeSinceLevelLoad >= TotalTime)
		{
			//make the total score object indestructible, so we can use it in the next scene
			DontDestroyOnLoad(Player);
			
			//load the last scene
			Application.LoadLevel("endCS"); //load the game level
		}
	}
}

