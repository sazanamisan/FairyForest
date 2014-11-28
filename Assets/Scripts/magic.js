#pragma strict

static var targetGameObject : GameObject;
private var center : Vector3;
var FireSE : AudioClip;
var IceSE : AudioClip;
var SanderSE : AudioClip;
 
function Start () {
    // 画面中央の座標を取得。
    center = Vector3(Screen.width/2, Screen.height/2, 0);
}
 
function Update () {
// マウスカーソルを削除する
    Screen.showCursor = false;
    // マウスカーソルを画面内にロックする
    Screen.lockCursor = true;
    // マウスクリック
    if (guiText.text == "火") {
    if (Input.GetButtonDown("Fire1")) {
        fire();
        audio.PlayOneShot(FireSE);
    }
    }
    else if (guiText.text == "氷") {
    if (Input.GetButtonDown("Fire1")) {
        fire();
        audio.PlayOneShot(IceSE);
    }
    }
    else if (guiText.text == "雷") {
    if (Input.GetButtonDown("Fire1")) {
        fire();
        audio.PlayOneShot(SanderSE);
    }
    }
}
 
function fire() {
    var ray : Ray;
    var hit : RaycastHit;
    // 画面真ん中へ Ray を飛ばす
    ray = Camera.main.ScreenPointToRay(center);
 
    // 何かにぶつかったら gameObject を取得
    if (Physics.Raycast(ray, hit, 1000)) {
        targetGameObject = hit.collider.gameObject;
    } else {
        targetGameObject = null;
    }
}