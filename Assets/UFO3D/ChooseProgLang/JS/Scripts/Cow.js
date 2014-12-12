//This script controls the movement of the cow along the landscape, and picking it up by the player

var Landscape:Transform; //The landscape object
var Player:Transform; //The player object

private var RotateSpeed:float = 0; //Rotation speed of the object
private var PickUpCheck:boolean = false; //Check wether the object has been picked up already
private var Delay:int = 0; //used to make the object's movement a little random

function Start()
{
	transform.parent = Landscape.transform; //Set this object as a child of the landscape object
	transform.Rotate(Vector3.up, Random.value * 360, Space.Self); //Give this object a random rotation
	
	RotateSpeed = Random.value * 1 - 0.5; //give this object a random speed
}

function Update () 
{		
	//If the object hasn't been picked up by the player, keep it moving around
	if ( !PickUpCheck  )
	{
		transform.Rotate(Vector3.up, RotateSpeed, Space.Self); //rotate the object around the up axis
		transform.Rotate(Vector3.forward, 0.1, Space.Self); //rotate the object around the forward axis
	}
	
	//Pick up the object if it gets within range of PickUpRadius
	if ( Player.GetComponent("UFOcontrol").PickUpCheck == false && Vector3.Distance(transform.Find("Cow").position, Player.position + Vector3.up * Player.GetComponent("UFOcontrol").PickUpOffset) < Player.GetComponent("UFOcontrol").PickUpRadius )
	{
		audio.Play(); //play a pickup sound
		
		Player.Find("BeamGreen").position = Vector3.zero; //reset the green beam's position
		Player.Find("BeamRed").position = Player.position; //put the red beam's position where the player is
		
		transform.position = Vector3.zero; //move this object to position (0,0,0)
		
		transform.Find("Cow").parent = Player.transform; //make this object the child of the player object
		
		Player.GetComponent("UFOcontrol").SpawnPoint = transform; //put the current spawn point inside the value of SpawnPoint inside "UFOcontrol". This will be used later to determine where to put the picked up object back
		
		Player.GetComponent("UFOcontrol").PickUpCheck = true; //set the pickup check to true, so no other object can be picked up
	}
	
	//These lines of code make the object scale up gradually from 0.1 to 1
	if ( Delay > 0 )
	{
		Delay--;
		
		transform.renderer.enabled = false;
	}
	else if ( Delay == 0 )
	{
		Delay--;
		
	    transform.renderer.enabled = true;
	}
}