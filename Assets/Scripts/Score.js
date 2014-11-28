#pragma strict

static var score : int;
 
function Awake() {
    // init
    score = 0;
}
 
function Update () {
    guiText.text = "Score:" + score.ToString();
}