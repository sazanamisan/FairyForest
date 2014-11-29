using UnityEngine;
using System.Collections;
using Leap;

public class ElementStatus : MonoBehaviour {
	
	Controller controller = new Controller();
	
	public int FingerCount;
	public int HandCount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
		HandCount = frame.Hands.Count;
		
		
		if(HandCount == 1) {
		if ( FingerCount >= 4) {
			guiText.text = "火";
		}
		else if ( FingerCount >= 2) {
			guiText.text = "氷";
			}
		else {
		guiText.text = "雷";
			}
		}
	}
}
