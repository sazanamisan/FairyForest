﻿#pragma strict

function Update () {

	transform.position.z -= 0.02;
	
	if(transform.position.z < 8.5) {
		Application.LoadLevel("GameOver");
     	}
     }