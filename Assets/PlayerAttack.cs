using UnityEngine;
using System.Collections;
using Leap;

public class PlayerAttack : MonoBehaviour {


	Controller controller = new Controller();
	public int FingerCount;
	public Texture OnePlayercrosshairImage;
	public Texture TwoPlayercrosshairImage;
	public AudioClip FireSE;
	public AudioClip IceSE;
	public AudioClip SanderSE;
	public GameObject targetGameObject;
	
	
	void Start() { 
		
		}
	
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
		/*InteractionBox iBox = frame.InteractionBox;
		Vector handCenter = firstHand.PalmPosition;
		Vector normalizedPosition = iBox.NormalizePoint(handCenter);
		
		if (Input.GetButtonDown("Fire1")) {
		Ray ray;
    	RaycastHit hit;
    	
    	ray = Camera.main.ScreenPointToRay(normalizedPosition);
    	
    	 if (Physics.Raycast(ray, out hit, 1000)) {
        targetGameObject = hit.collider.gameObject;
    } else {
        targetGameObject = null;
    }
    }*/
		


		/*InteractionBox iBox = frame.InteractionBox;

		Vector firstHandnormalizedPosition = iBox.NormalizePoint(firstHand.PalmPosition);
		Vector secondHandnormalizedPosition = iBox.NormalizePoint(secondHand.PalmPosition);*/


		float firsthandX = firstHand.PalmPosition.x + 300;
		float firsthandY = -firstHand.PalmPosition.y + 600;
		
		float secondhandX = secondHand.PalmPosition.x + 900;
		float secondhandY = -secondHand.PalmPosition.y + 600;
		
		
		
		

		GUI.DrawTexture (new Rect (firsthandX + (OnePlayercrosshairImage.width / 2),
		                           firsthandY - (OnePlayercrosshairImage.height / 2),
		                           OnePlayercrosshairImage.width,
		                           OnePlayercrosshairImage.height), OnePlayercrosshairImage);
		                           
		GUI.DrawTexture (new Rect (secondhandX + (TwoPlayercrosshairImage.width / 2),
		                           secondhandY - (TwoPlayercrosshairImage.height / 2),
		                           TwoPlayercrosshairImage.width,
		                           TwoPlayercrosshairImage.height), TwoPlayercrosshairImage);		

			}

}
}
