//THis script spins an object around two axis

var Target:Transform; //The target object

function Update () 
{
	Target.Rotate(Vector3.up, 3, Space.World); //rotate the target object around the up axis
	Target.Rotate(Vector3.right, 2, Space.Self); //rotate the target object around the right axis
}