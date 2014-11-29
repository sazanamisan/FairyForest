#pragma strict

function Update () {
	transform.position += transform.forward * Time.deltaTime * 15;
}


function OnCollisionEnter(col : Collision){
	Destroy (gameObject);
}