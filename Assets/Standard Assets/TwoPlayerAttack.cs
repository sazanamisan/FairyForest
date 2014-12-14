using UnityEngine;
using System.Collections;
using Leap;

public class TwoPlayerAttack : MonoBehaviour {


	Controller controller = new Controller();
	public static int FingerCount;
	public int HandCount;
	public Texture TwoPlayercrosshairImage;
	public AudioClip FireSE;
	public AudioClip IceSE;
	public AudioClip SanderSE;
	public static GameObject targetGameObject;
	private bool Attack = true;
	
	public UnityEngine.Vector3 secondhand = new UnityEngine.Vector3();
		
	void Start() { 
		
		}
	
	void Update() {
	

    // マウスカーソルを画面内にロックする
    //UnityEngine.Screen.lockCursor = true;
	
		Frame frame = controller.Frame();
		FingerCount = frame.Hands[1].Fingers.Count;
		
		
	}
	
	void Ray(){
		Ray ray;
    	RaycastHit hit;
    	
    	ray = Camera.main.ScreenPointToRay(secondhand);
    	
    	 if (Physics.Raycast(ray, out hit, 1000)) {
        targetGameObject = hit.collider.gameObject;
    } else {
        targetGameObject = null;
    }
    }


	
    

	void OnGUI()
{	
	if (controller.IsConnected) {
		Frame frame = controller.Frame();	

		HandList hands = frame.Hands;
		Hand secondHand = hands[1];
		HandCount = frame.Hands.Count;
		
		
		
		if (Attack == true ) {
		if (FingerCount == 5) {
			Ray();
			audio.PlayOneShot(FireSE);
			Attack = false;
			}
		else if ( FingerCount == 2) {
			Ray();
			audio.PlayOneShot(IceSE);
			Attack = false;
			}
		else if ( FingerCount ==1) {
			Ray();
			audio.PlayOneShot(SanderSE);
			Attack = false;
			}
		}
		if(FingerCount == 0 ) {
		Attack = true;
		}


		secondhand.x = secondHand.PalmPosition.x + 500;
		secondhand.y = -secondHand.PalmPosition.y + 500;
		                           
		GUI.DrawTexture (new Rect (secondhand.x - (TwoPlayercrosshairImage.width / 2),
		                           secondhand.y + (TwoPlayercrosshairImage.height / 2),
		                           TwoPlayercrosshairImage.width,
		                           TwoPlayercrosshairImage.height), TwoPlayercrosshairImage);		

			}

}
}
