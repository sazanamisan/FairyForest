using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	int speed = 10000;
 
void Start () {
 
 rigidbody.AddForce (Vector3.forward * speed);
 
}

	
	// Update is called once per frame
	void Update () {
	
	}
}
