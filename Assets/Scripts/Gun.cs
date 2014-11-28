using UnityEngine;
using System.Collections;
 
/**
* 弾.
*/
public class Gun : MonoBehaviour {
 
float m_CurrentTime = 0.0f;
float m_Life = 4.0f;
float m_Speed = 10.0f;
Vector3 m_Direction = Vector3.zero;
 
// Use this for initialization
void Start () {
 
}
 
// Update is called once per frame
void Update () {
 
// 移動.
transform.position += m_Speed * m_Direction;
 
// 生存時間.
if(m_Life <= m_CurrentTime) {
Destroy(gameObject);
}
m_CurrentTime += Time.deltaTime;
}
 
public void SetParam(Vector3 pos, Vector3 dir, float speed) {
transform.position = pos;
m_Speed = speed;
m_Direction = dir;
}
}