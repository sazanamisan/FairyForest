﻿#pragma strict

function Update () {

	transform.position.z -= 0.01;
	
	if(transform.position.z < 6.2) {
		Application.LoadLevel("GameOver");
     	}
     }
