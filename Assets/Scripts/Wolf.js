#pragma strict

var enemy : Transform;

var w = true;

function Start(){
}

function Update () {
	if ( w == true ) {
	if (Time.frameCount % 200 == 0) {
		Instantiate(enemy, Vector3(Random.Range(13,18),0,20), transform.rotation);
		}
		if ( Score.score > 39 ) {
		w = false;
		}
	}
}