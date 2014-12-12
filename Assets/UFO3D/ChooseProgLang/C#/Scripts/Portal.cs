using UnityEngine;

/// <summary>
/// This attaches an object to the landscape object, and spins it around itself.
/// </summary>
public class Portal : MonoBehaviour
{
	public Transform Landscape; //The landscape object

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
		if (Landscape) 
			transform.parent = Landscape.transform; //make this object the child of the landscape object
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		transform.Find("Portal").Rotate(Vector3.forward * Time.deltaTime * 1.5f, 1.5f, Space.Self); //spin this object around itself
	}
}

