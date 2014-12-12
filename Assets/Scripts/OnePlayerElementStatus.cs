using UnityEngine;
using System.Collections;
using Leap;

public class OnePlayerElementStatus : MonoBehaviour {
	
	Controller controller = new Controller();
	
	public int FingerCount;
	public int HandCount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		FingerCount = frame.Hands[0].Fingers.Count;
		HandCount = frame.Hands.Count;
		
		if (FingerCount == 5) {
			guiText.text = "1P" + "火";
		}
		else if (FingerCount == 2) {
			guiText.text = "1P" + "氷";
			}
		else if (FingerCount ==1) {
			guiText.text = "1P" + "雷";
			}
		if(FingerCount == 0 ) {
		guiText.text = "1P" + "無";
		}
	}
}
