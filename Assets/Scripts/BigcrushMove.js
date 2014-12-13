#pragma strict

function Update () {

	transform.position.z -= 0.03;
	
	if(transform.position.z < 6.2) {
		Application.LoadLevel("GameOver");
     	}
     }
