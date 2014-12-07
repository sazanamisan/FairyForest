#pragma strict

function Start () {

}

function Update () {
	if(transform.position.z == 8.5) {
         Application.LoadLevel("GameOver");
     }

}