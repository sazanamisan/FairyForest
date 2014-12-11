using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


public static int score;
 
void  Awake (){
    score = 0;
}
 
void  Update (){
    guiText.text = "Score:" + score.ToString();
}
}