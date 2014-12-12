using UnityEngine;

/// <summary>
/// This script shows a GUI texture on screen, scaling it up from 1 pixel to 64.
/// Used to show a cow head whenever a cow is put in the portal.
/// </summary>
public class CowHeadGUI : MonoBehaviour
{
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
		transform.guiTexture.pixelInset.Set(transform.guiTexture.pixelInset.xMin,
											transform.guiTexture.pixelInset.yMin,
											1,
											1); //set pixel width and height tp 1
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (transform.guiTexture.pixelInset.width < 64) //limit pixel width and height to 64
		{
			transform.guiTexture.pixelInset.Set(transform.guiTexture.pixelInset.xMin,
												transform.guiTexture.pixelInset.yMin,
												transform.guiTexture.pixelInset.width + 2,
												transform.guiTexture.pixelInset.height + 2); //increase pixel width and height
		}
	}
}

