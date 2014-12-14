#pragma strict

var enemy : Transform;
var b = true;

function Start(){
}

function Update () {
/*if (Time.frameCount % 170 == 0) {
		Instantiate(enemy, Vector3(Random.Range(13,18),0,20), transform.rotation);
	}*/
	if ( b == true ) {
	if (Score.score > 30) {
	if (Time.frameCount % 150 == 0) {
		Instantiate(enemy, Vector3(Random.Range(10,20),0,20), transform.rotation);
	}
	}
	if ( Score.score > 39 ) {
		b = false;
		}
	}
}