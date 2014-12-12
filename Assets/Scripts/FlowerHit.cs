﻿using UnityEngine;
using System.Collections;

public class FlowerHit : MonoBehaviour {


public GameObject fire;
public GameObject ice;
public GameObject sander;
float s = -0.02f;

void  Update (){
    if (this.gameObject == OnePlayerAttack.targetGameObject | 
    	TwoPlayerAttack.targetGameObject) {
    	if (OnePlayerAttack.FingerCount == 5 | TwoPlayerAttack.FingerCount == 5) {
    	Instantiate(fire, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
        if (OnePlayerAttack.FingerCount == 5 | TwoPlayerAttack.FingerCount == 5) {
        Instantiate(ice, transform.position, transform.rotation);
        transform.Translate(Vector3.back * s);
        }
        
        if (OnePlayerAttack.FingerCount == 5 | TwoPlayerAttack.FingerCount == 5) {
        Instantiate(sander, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
}
}
}