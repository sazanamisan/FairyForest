using UnityEngine;
using System.Collections;

public class hit : MonoBehaviour {


public GameObject fire;
public GameObject ice;
public GameObject sander;

void  Update (){
	
    // shot スクリプト内の targetGameObject がこの gameObject だったら消す
    if (this.gameObject == OnePlayerAttack.targetGameObject) {
    	if ( guiText.text == "1P" + "火") {
    	Instantiate(fire, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
        if ( guiText.text == "1P" + "氷") {
        Instantiate(ice, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
        
        if ( guiText.text == "1P" + "雷") {
        Instantiate(sander, transform.position, transform.rotation);
        Destroy(gameObject);
        Score.score +=1;
        }
}
}
}