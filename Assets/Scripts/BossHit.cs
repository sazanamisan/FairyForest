using UnityEngine;
using System.Collections;

public class BossHit : MonoBehaviour {


public GameObject fire;
public GameObject ice;
public GameObject sander;
public int BossHP = 10;

void  Update (){

    if (this.gameObject == OnePlayerAttack.targetGameObject) {
    	if ( OnePlayerAttack.FingerCount == 5) {
    	Instantiate(fire, transform.position, transform.rotation);
    	if ( BossHP == 0 ) {
    	Destroy(gameObject);
    	}
        }
        if ( OnePlayerAttack.FingerCount == 2) {
        Instantiate(ice, transform.position, transform.rotation);
        }
        
        if ( OnePlayerAttack.FingerCount == 1) {
        Instantiate(sander, transform.position, transform.rotation);
        }
        
}
	if (this.gameObject == TwoPlayerAttack.targetGameObject) {
    	if ( TwoPlayerAttack.FingerCount == 5) {
    	Instantiate(fire, transform.position, transform.rotation);
        }
        if ( TwoPlayerAttack.FingerCount == 2) {
        Instantiate(ice, transform.position, transform.rotation);
        }
        
        if ( TwoPlayerAttack.FingerCount == 1) {
        Instantiate(sander, transform.position, transform.rotation);
        }
}
}
}