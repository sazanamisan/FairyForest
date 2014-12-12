//This script controls the player's movement, picking and dropping off cows at the portal.

var Speed:float = 1; //The speed of the object
var Landscape:Transform; //the landscape object
var Clouds:Transform; //the clouds object
var Portal:Transform; //the portal object

var FloatRange:float = 0.1; //the object's floating range
var FloatSpeed:float = 2; //the object's floating range

var PickUpRadius= 0.5; //the object's pick up radius
var PickUpOffset = -1.7; //the object's pick up radius offset

var PortalEffect:Transform; //the effect that shows up when you drop off a cow

var CowHeadGUI:Transform; //the gui textre that shows when you drop off a cow

var dSpeed:float = 100;

private var Score:int = 0; //total score

private var SpeedX:float = 0; //current horizontal speed
private var SpeedZ:float = 0; //current vertical speed
private var SpeedXmax:float = 0; //maximum horizontal speed
private var SpeedZmax:float = 0; //maximum vertical speed

private var OriginalPosY:float; //the original y position of the object

private var PickUpCheck:boolean = false; //check if we've already picked up a cow

private var SpawnPoint:Transform; //used to hold the picked up cow's spawn point, so we can return the cow to it later

private var PortalEffectCopy:Object; //a copy of the portal effect

private var CowHeadGUICopy:Object; //a copy of the gui texture
private var CowHeadGUIOffset:float = 0; //used to create the texture at a further position each time

function Start()
{
	SpeedXmax = SpeedZmax = Speed; //Set the maximum horizontal/vertical speeds to the value of Speed
	
	OriginalPosY = transform.position.y; //set the original position to the current position
}

function Update () 
{
	//Control the horizontal movement
	if ( Input.mousePosition.x < Screen.width * 0.4 ) //if the mouse is on the left side of the screen...
	{
		if ( SpeedX < SpeedXmax ) //...and the object's speed is lower than the maximum horizontal speed...
		{
			SpeedX += 0.1; //...increase its speed
		}
	}
	else if ( Input.mousePosition.x > Screen.width * 0.6 ) //otherwise, if the mouse is on the right side of the screen...
	{
		if ( SpeedX > -SpeedXmax )  //...and the object's reverse speed is lower than the maximum reverse horizontal speed...
		{
			SpeedX -= 0.1; //...decrease its speed
		}
	}
	else if ( Mathf.Abs(SpeedX) > 0.01 ) //otherwise, if you're in the middle horizontally...
	{	
		SpeedX *= 0.9; //...slow down to a halt
	}
	
	//Rotate the landscape, the clouds, and the ufo horizontally based on the value of SpeedX
	Landscape.Rotate(Vector3(0,0,-1), SpeedX * Time.deltaTime * dSpeed, Space.World);
	Clouds.Rotate(Vector3(0,0,-1), SpeedX * 0.1 * Time.deltaTime * dSpeed, Space.World);
	transform.Rotate(Vector3(0,0,1), SpeedX * 2 * Time.deltaTime * dSpeed, Space.World);
	
	//Limit the rotation of the player object
	if ( transform.rotation.z > 0.05 )
	{
		transform.rotation.z = 0.05;
	}
	
	//Limit the rotation of the player object
	if ( transform.rotation.z < -0.05 )
	{
		transform.rotation.z = -0.05;
	}
	
	//Control the vertical movement
	if ( Input.mousePosition.y > Screen.height * 0.6 ) //if the mouse is on the upper side of the screen...
	{
		if ( SpeedZ < SpeedZmax ) //...and the object's speed is lower than the maximum vertical speed...
		{
			SpeedZ += 0.1; //...increase its speed
		}
	}
	else if ( Input.mousePosition.y < Screen.height * 0.4 ) //otherwise, if the mouse is on the lower side of the screen...
	{
		if ( SpeedZ > -SpeedZmax ) //...and the object's reverse speed is lower than the maximum reverse vertical speed...
		{
			SpeedZ -= 0.1; //...decrease its speed
		}
	}
	else if ( Mathf.Abs(SpeedZ) > 0.01 ) //otherwise, if you're in the middle vertically...
	{	
		SpeedZ *= 0.9; //...slow down to a halt
	}
	
	//Rotate the landscape, the clouds, and the ufo vertically based on the value of SpeedY
	Landscape.Rotate(Vector3(-1,0,0), SpeedZ * Time.deltaTime * dSpeed, Space.World);
	Clouds.Rotate(Vector3(-1,0,0), SpeedZ * 0.1 * Time.deltaTime * dSpeed, Space.World);
	Clouds.Rotate(Vector3.up, -0.1 * Time.deltaTime * dSpeed, Space.World);
	transform.Rotate(Vector3(1,0,0), SpeedZ * 2 * Time.deltaTime * dSpeed, Space.World);
	
	//Limit the rotation of the player object
	if ( transform.rotation.x > 0.05 )
	{
		transform.rotation.x = 0.05;
	}
	
	//Limit the rotation of the player object
	if ( transform.rotation.x < -0.05 )
	{
		transform.rotation.x = -0.05;
	}
	
	//Make the player object hover
	transform.position.y = OriginalPosY + (1 + Mathf.Sin(Time.time * FloatSpeed)) * FloatRange * 0.5;

	//picked up a cow
	if ( PickUpCheck == true )
	{
		//Move the picked up object towards a spot below the player object
		transform.Find("Cow").position -= (transform.Find("Cow").position - (transform.position + Vector3.up * -0.9)) * 0.05;
	
		//spin the picked up object
		transform.Find("Cow").Rotate(Vector3.forward, Random.value, Space.World);
	
		//If the picked up object is close enough to the portal, drop it off and add to the score
		if ( Vector3.Distance(transform.Find("Cow").position, Portal.Find("Portal").position) < 0.5 )
		{
			PickUpCheck = false;
			
			//create a portal effect, and attach it to the landscape object
			PortalEffectCopy = Instantiate(PortalEffect, transform.Find("Cow").position, transform.Find("Cow").rotation);
			PortalEffectCopy.transform.parent = Landscape;
			
			//add a score texture (the cow head)
			CowHeadGUICopy = Instantiate(CowHeadGUI, Vector3(CowHeadGUIOffset,0.85,0), Quaternion.identity);
			CowHeadGUIOffset += 0.03;
			
			//attach the cow back to its original spwan point
			transform.Find("Cow").parent = SpawnPoint;
			
			//reset the cow to its spawn points position and rotation
			SpawnPoint.Find("Cow").position = SpawnPoint.Find("SpawnPosition").position;
			SpawnPoint.Find("Cow").rotation = SpawnPoint.Find("SpawnPosition").rotation;
			
			//set a delay for the cow, so it doesnt show immediately at the spawn point
			SpawnPoint.GetComponent("Cow").Delay = Random.value * 200 + 300;
			
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

function OnDrawGizmos() 
{
	// Display the pick up radius in the editor screen
	Gizmos.color = Color.white;
	Gizmos.DrawWireSphere (transform.position + Vector3.up * PickUpOffset, PickUpRadius);
}
