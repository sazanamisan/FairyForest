using UnityEngine;

/// <summary>
/// This script displays a score and a restart button.
/// </summary>
public class GUInterfaceEnd : MonoBehaviour
{
	public GUISkin mySkin; //The GUISkin we'll use, which holds info about the fonts and styles in the interface

	private int ScoreText; //the description text

	/// <summary>
	/// Start is called just before any of the Update methods is called the first time.
	/// 
	/// Start is only called once in the lifetime of the behaviour. The difference between Awake and
	/// Start is that Start is only called if the script instance is enabled.
	/// This allows you to delay any initialization code, until it is really needed.
	/// Awake is always called before any Start functions. This allows you to order initialization of scripts. 
	/// 
	/// The Start function is called after all Awake functions on all script instances have been called. 
	/// </summary>
	void Start()
	{
		ScoreText = GameObject.Find("UFO").GetComponent<UFOcontrol>().Score; //set the score based on the UFO object carried over from the previous game scene

		Destroy(GameObject.Find("UFO")); //destroy the UFO object carried over from the previous game scene
	}

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// </summary>
	void OnGUI()
	{
		//Set the general GUI style we're going to use
		GUI.skin = mySkin;

		//Score text
		GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, Screen.height * 0.1f), ScoreText.ToString() + " Cows collected!");

		// The restart button
		if (GUI.Button(new Rect(0, Screen.height * 0.9f, Screen.width, Screen.height * 0.1f), "Click to Restart"))
		{
			Application.LoadLevel("startCS"); //load the game level
		}
	}
}
