#pragma strict

var enemy : Transform;

function Start(){
}

function Update () {

	if (Time.frameCount % 100 == 0) {
		Instantiate(enemy, Vector3(Random.Range(13,20),0,20), transform.rotation);
	}
}