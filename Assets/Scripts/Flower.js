#pragma strict

var enemy : Transform;
var f = true;

function Start(){
}

function Update () {
/*if (Time.frameCount % 170 == 0) {
		Instantiate(enemy, Vector3(Random.Range(13,18),0,20), transform.rotation);
	}*/
	
	if ( f == true ) {
	if (Score.score > 10) {
	if (Time.frameCount % 170 == 0) {
		Instantiate(enemy, Vector3(Random.Range(13,18),0,20), transform.rotation);
	}
	}
	if ( Score.score > 39 ) {
		f = false;
		}
	}
}