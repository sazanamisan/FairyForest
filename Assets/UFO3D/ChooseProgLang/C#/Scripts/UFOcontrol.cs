using UnityEngine;

/// <summary>
/// This script controls the player's movement, picking and dropping off cows at the portal.
/// </summary>
public class UFOcontrol : MonoBehaviour
{
	public float Speed = 1.0f; //The speed of the object
	public Transform Landscape; //the landscape object
	public Transform Clouds; //the clouds object
	public Transform Portal; //the portal object
	public float FloatRange = 0.1f; //the object's floating range
	public float FloatSpeed = 2.0f; //the object's floating range
	public float PickUpRadius = 0.5f; //the object's pick up radius
	public float PickUpOffset = -1.7f; //the object's pick up radius offset
	public Transform PortalEffect; //the effect that shows up when you drop off a cow
	public Transform CowHeadGUI; //the gui textre that shows when you drop off a cow
	public float dSpeed = 100.0f;

	internal bool PickUpCheck = false; //check if we've already picked up a cow
	internal Transform SpawnPoint; //used to hold the picked up cow's spawn point, so we can return the cow to it later
	internal int Score = 0; //total score

#pragma warning disable 414

	private float SpeedX = 0.0f; //current horizontal speed
	private float SpeedZ = 0.0f; //current vertical speed
	private float SpeedXmax = 0.0f; //maximum horizontal speed
	private float SpeedZmax = 0.0f; //maximum vertical speed	
	private float OriginalPosY = 0.0f; //the original y position of the object
	private Transform PortalEffectCopy; //a copy of the portal effect
	private Transform CowHeadGUICopy; //a copy of the gui texture

#pragma warning restore 414

	private float CowHeadGUIOffset = 0.0f; //used to create the texture at a further position each time

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
		SpeedXmax = SpeedZmax = Speed; //Set the maximum horizontal/vertical speeds to the value of Speed
		OriginalPosY = transform.position.y; //set the original position to the current position
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		//Control the horizontal movement
		if (Input.mousePosition.x < Screen.width * 0.4f) //if the mouse is on the left side of the screen...
		{
			if (SpeedX < SpeedXmax) //...and the object's speed is lower than the maximum horizontal speed...
			{
				SpeedX += 0.1f; //...increase its speed
			}
		}
		else if (Input.mousePosition.x > Screen.width * 0.6f) //otherwise, if the mouse is on the right side of the screen...
		{
			if (SpeedX > -SpeedXmax)  //...and the object's reverse speed is lower than the maximum reverse horizontal speed...
			{
				SpeedX -= 0.1f; //...decrease its speed
			}
		}
		else if (Mathf.Abs(SpeedX) > 0.01f) //otherwise, if you're in the middle horizontally...
		{
			SpeedX *= 0.9f; //...slow down to a halt
		}

		//Rotate the landscape, the clouds, and the ufo horizontally based on the value of SpeedX
		Landscape.Rotate(-Vector3.forward, SpeedX * Time.deltaTime * dSpeed, Space.World);
		Clouds.Rotate(-Vector3.forward, SpeedX * 0.1f * Time.deltaTime * dSpeed, Space.World);
		transform.Rotate(new Vector3(0, 0, 1f), SpeedX * 2, Space.World);

		//Limit the rotation of the player object
		if (transform.rotation.z > 0.05f)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, 0.05f);
			//transform.rotation = Quaternion.Euler(eulerAngles);
			transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0.05f, transform.rotation.w);

			//transform.rotation.Set(transform.rotation.x, transform.rotation.y, 0.05f, transform.rotation.w);
		}
		//Limit the rotation of the player object
		if (transform.rotation.z < -0.05f)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, -0.05f);
			//transform.rotation = Quaternion.Euler(eulerAngles);

			transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, -0.05f, transform.rotation.w);

		}

		//Control the vertical movement
		if (Input.mousePosition.y > Screen.height * 0.6f) //if the mouse is on the upper side of the screen...
		{
			if (SpeedZ < SpeedZmax) //...and the object's speed is lower than the maximum vertical speed...
			{
				SpeedZ += 0.1f; //...increase its speed
			}
		}
		else if (Input.mousePosition.y < Screen.height * 0.4f) //otherwise, if the mouse is on the lower side of the screen...
		{
			if (SpeedZ > -SpeedZmax) //...and the object's reverse speed is lower than the maximum reverse vertical speed...
			{
				SpeedZ -= 0.1f; //...decrease its speed
			}
		}
		else if (Mathf.Abs(SpeedZ) > 0.01f) //otherwise, if you're in the middle vertically...
		{
			SpeedZ *= 0.9f; //...slow down to a halt
		}

		//Rotate the landscape, the clouds, and the ufo vertically based on the value of SpeedY
		Landscape.Rotate(-Vector3.right, SpeedZ * Time.deltaTime * dSpeed, Space.World);
		Clouds.Rotate(-Vector3.right, SpeedZ * 0.1f * Time.deltaTime * dSpeed, Space.World);
		Clouds.Rotate(Vector3.up, -0.1f * Time.deltaTime * dSpeed, Space.World);
		transform.Rotate(new Vector3(1f, 0, 0), SpeedZ * 2, Space.World);

		//Limit the rotation of the player object
		if (transform.rotation.x > 0.05f)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles = new Vector3(0.05f, eulerAngles.y, eulerAngles.z);
			//transform.rotation = Quaternion.Euler(eulerAngles);
			transform.rotation = new Quaternion(0.05f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
			//transform.rotation.Set(0.05f, transform.rotation.y, transform.rotation.z, transform.rotation.z);
		}

		//Limit the rotation of the player object
		if (transform.rotation.x < -0.05)
		{
			Vector3 eulerAngles = transform.rotation.eulerAngles;
			eulerAngles = new Vector3(-0.05f, eulerAngles.y, eulerAngles.z);
//			transform.rotation = Quaternion.Euler(eulerAngles);
			transform.rotation = new Quaternion(-0.05f, transform.rotation.y, transform.rotation.z, transform.rotation.w);
			//transform.rotation.Set(-0.05f, transform.rotation.y, transform.rotation.z, transform.rotation.z);
		}

		//Make the player object hover
		transform.position = new Vector3(transform.position.x, OriginalPosY + (1 + Mathf.Sin(Time.time * FloatSpeed)) * FloatRange * 0.5f, transform.position.z);
		
		//picked up a cow
		if (PickUpCheck == true)
		{
			//Move the picked up object towards a spot below the player object
			transform.Find("Cow").position -= (transform.Find("Cow").position - (transform.position + Vector3.up * -0.9f)) * 0.05f;

			//spin the picked up object
			transform.Find("Cow").Rotate(Vector3.forward, Random.value, Space.World);

			//If the picked up object is close enough to the portal, drop it off and add to the score
			if (Vector3.Distance(transform.Find("Cow").position, Portal.Find("Portal").position) < 0.5f)
			{
				PickUpCheck = false;
			
				//create a portal effect, and attach it to the landscape object
				PortalEffectCopy = (Transform)Instantiate(PortalEffect, transform.Find("Cow").position, transform.Find("Cow").rotation);
				PortalEffectCopy.transform.parent = Landscape;

				//add a score texture (the cow head)
				CowHeadGUICopy = (Transform)Instantiate(CowHeadGUI, new Vector3(CowHeadGUIOffset, 0.85f, 0), Quaternion.identity);
				CowHeadGUIOffset += 0.03f;

				//attach the cow back to its original spwan point
				transform.Find("Cow").parent = SpawnPoint;

				//reset the cow to its spawn points position and rotation
				SpawnPoint.Find("Cow").position = SpawnPoint.Find("SpawnPosition").position;
				SpawnPoint.Find("Cow").rotation = SpawnPoint.Find("SpawnPosition").rotation;

				//set a delay for the cow, so it doesnt show immediately at the spawn point
				SpawnPoint.GetComponent<Cow>().Delay = (int)Random.value * 200 + 300;

				//switch back the positions of the green and red beams. Now the green beam will be visible and the red one will not be seen
				transform.Find("BeamGreen").position = transform.position;
				transform.Find("BeamRed").position = Vector3.zero;

				//add to the score
				Score++;

				//Play Portal sound
				audio.Play();
			}
		}
	}

	/// <summary>
	/// Display the radius while in the editor.
	/// </summary>
	void OnDrawGizmos()
	{
		// Display the pick up radius in the editor screen
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position + Vector3.up * PickUpOffset, PickUpRadius);
	}
}
