using UnityEngine;
using System.Collections;

public class WolfHit : MonoBehaviour {


public GameObject fire;
public GameObject ice;
public GameObject sander;
float s = 1.0f;

void  Update (){
	
    // shot スクリプト内の targetGameObject がこの gameObject だったら消す
    if (this.gameObject == PlayerAttack.targetGameObject) {
    	if ( guiText.text == "火") {
    	Instantiate(fire, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
        if ( guiText.text == "氷") {
        Instantiate(ice, transform.position, transform.rotation);
        transform.Translate(Vector3.back * s);
        }
        
        if ( guiText.text == "雷") {
        Instantiate(sander, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
}
}
}