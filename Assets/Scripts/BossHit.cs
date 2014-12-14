using UnityEngine;
using System.Collections;

public class BossHit : MonoBehaviour {


public GameObject fire;
public GameObject ice;
public GameObject sander;

void  Update (){
	if ( Score.score > 39) {
    if (this.gameObject == OnePlayerAttack.targetGameObject) {
    	if ( OnePlayerAttack.FingerCount == 5) {
    	Instantiate(fire, transform.position, transform.rotation);
    	Destroy(gameObject);
    	Application.LoadLevel("GameClear");
        }
         if ( OnePlayerAttack.FingerCount == 2) {
         Instantiate(ice, transform.position, transform.rotation);
         Destroy(gameObject);
         Application.LoadLevel("GameClear");
        }
        
         if ( OnePlayerAttack.FingerCount == 1) {
         Instantiate(sander, transform.position, transform.rotation);
         Destroy(gameObject);
         Application.LoadLevel("GameClear");
        }
        
}
	if ( Score.score > 49) {
	if (this.gameObject == TwoPlayerAttack.targetGameObject) {
    	if ( TwoPlayerAttack.FingerCount == 5) {
    	Instantiate(fire, transform.position, transform.rotation);
    	Destroy(gameObject);
    	Application.LoadLevel("GameClear");
        }
        if ( TwoPlayerAttack.FingerCount == 2) {
        Instantiate(ice, transform.position, transform.rotation);
        Destroy(gameObject);
        Application.LoadLevel("GameClear");
        }
        
        if ( TwoPlayerAttack.FingerCount == 1) {
        Instantiate(sander, transform.position, transform.rotation);
        Destroy(gameObject);
        Application.LoadLevel("GameClear");
        }
        }
}
}
}
}