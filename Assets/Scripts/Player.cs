using UnityEngine;
using System.Collections;
 
/**
* @brief プレイヤーにする.
*/
public class Player : MonoBehaviour {
 
// Use this for initialization
void Start () {
 
}
 
// Update is called once per frame
void Update () {
if (Input.GetMouseButtonDown(0)) {
// タップ位置から光線を出す.
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//発射位置と方向、スピードを設定.
Shot (ray.origin, ray.direction, 10.0f);
}
}
 
/**
* 弾を撃つ.
*/
void Shot(Vector3 pos, Vector3 dir, float speed) {
// プレファブをロードして、インスタンス作成.
GameObject go = GameObject.Instantiate(Resources.Load("Gun/Gun")) as GameObject;
Gun gun = go.GetComponent<Gun>();
gun.SetParam(pos, dir, speed);
}
}