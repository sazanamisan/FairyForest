using UnityEngine;
using System.Collections;

public class BigcrushHit : MonoBehaviour {


public GameObject fire;
public GameObject ice;
public GameObject sander;
float s = -0.03f;

void  Update (){

    if (this.gameObject == OnePlayerAttack.targetGameObject) {
    	if ( OnePlayerAttack.FingerCount == 5) {
    	//Instantiate(fire, transform.position, transform.rotation);
         transform.Translate(Vector3.back * s);
        }
        if ( OnePlayerAttack.FingerCount == 2) {
        Instantiate(ice, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
        
        if ( OnePlayerAttack.FingerCount == 1) {
        //Instantiate(sander, transform.position, transform.rotation);
        transform.Translate(Vector3.back * s);
        }
}
	if (this.gameObject == TwoPlayerAttack.targetGameObject) {
    	if ( TwoPlayerAttack.FingerCount == 5) {
    	//Instantiate(fire, transform.position, transform.rotation);
         transform.Translate(Vector3.back * s);
        }
        if ( TwoPlayerAttack.FingerCount == 2) {
        Instantiate(ice, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
        
        if ( TwoPlayerAttack.FingerCount == 1) {
        //Instantiate(sander, transform.position, transform.rotation);
        transform.Translate(Vector3.back * s);
        }
}
}
}