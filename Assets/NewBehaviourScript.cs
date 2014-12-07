using UnityEngine;
using System.Collections;
using Leap;

public class NewBehaviourScript : MonoBehaviour {

	Controller controller = new Controller();
	public int FingerCount;
	public Texture OnePlayercrosshairImage;
	public Texture TwoPlayercrosshairImage;
	
	void Update() {
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
		
	}
	
	
    

	void OnGUI()
{	
	if (controller.IsConnected) {
		Frame frame = controller.Frame();
		

		HandList hands = frame.Hands;
		Hand firstHand = hands[0];
		Hand secondHand = hands[1];
		//Vector stabilizedPosition = firstHand.StabilizedPalmPosition;


		/*InteractionBox iBox = frame.InteractionBox;

		Vector firstHandnormalizedPosition = iBox.NormalizePoint(firstHand.PalmPosition);
		Vector secondHandnormalizedPosition = iBox.NormalizePoint(secondHand.PalmPosition);*/


		float firsthandX = firstHand.PalmPosition.x + 600;
		float firsthandY = firstHand.PalmPosition.y + 100;
		
		float secondhandX = secondHand.PalmPosition.x + 600;
		float secondhandY = secondHand.PalmPosition.y + 100;
		
		
		
		

		GUI.DrawTexture (new Rect (firsthandX + (OnePlayercrosshairImage.width / 2),
		                           firsthandY - (OnePlayercrosshairImage.height / 2),
		                           OnePlayercrosshairImage.width,
		                           OnePlayercrosshairImage.height), OnePlayercrosshairImage);
		                           
		GUI.DrawTexture (new Rect (secondhandX + (TwoPlayercrosshairImage.width / 2),
		                           secondhandY - (TwoPlayercrosshairImage.height / 2),
		                           TwoPlayercrosshairImage.width,
		                           TwoPlayercrosshairImage.height), TwoPlayercrosshairImage);		


	 /*else {
				Vector2 mousePos = Event.current.mousePosition;
				GUI.DrawTexture (new Rect (mousePos.x - (crosshairImage.width / 2),
                          mousePos.y - (crosshairImage.height / 2),
                          crosshairImage.width,
                          crosshairImage.height), crosshairImage);
			}*/
			}

}
}
