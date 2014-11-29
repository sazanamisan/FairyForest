#pragma strict

function OnTriggerEnter (other : Collider) {

	if (other.name == "Player") {
		Application.LoadLevel("Clear");
	}
}