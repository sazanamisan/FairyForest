//This attaches an object to the landscape object, and spins it around itself

var Landscape:Transform; //The landscape object

function Start()
{
	if ( Landscape )    transform.parent = Landscape.transform; //make this object the child of the landscape object
}

function Update () 
{
	transform.Find("Portal").Rotate(Vector3.forward, 1.5, Space.Self); //spin this object around itself
}