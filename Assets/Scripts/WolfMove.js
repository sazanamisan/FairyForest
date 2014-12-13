#pragma strict

function Update () {

	transform.position.z -= 0.02;
	
	if(transform.position.z < 6.2) {
		Application.LoadLevel("GameOver");
     	}
     }
