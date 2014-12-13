using UnityEngine;
using System.Collections;
using Leap;

public class OnePlayerAttack : MonoBehaviour {


	Controller controller = new Controller();
	public static int FingerCount;
	public int HandCount;
	public Texture OnePlayercrosshairImage;
	public AudioClip FireSE;
	public AudioClip IceSE;
	public AudioClip SanderSE;
	public static GameObject targetGameObject;
	private bool Attack = true;
	
	
	
	public UnityEngine.Vector3 firsthand = new UnityEngine.Vector3();
		
	void Start() { 
		
		}
	
	void Update() {
	
		// マウスカーソルを削除する
    UnityEngine.Screen.showCursor = false;
    // マウスカーソルを画面内にロックする
    UnityEngine.Screen.lockCursor = true;
	
		Frame frame = controller.Frame();
		FingerCount = frame.Hands[0].Fingers.Count;
		
		
	}
	
	void Ray(){
		Ray ray;
    	RaycastHit hit;
    	
    	ray = Camera.main.ScreenPointToRay(firsthand);
    	
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
		Hand firstHand = hands[0];
		HandCount = frame.Hands.Count;
		
	
		if (Attack == true ) {
		if (FingerCount == 5) {
			guiText.text = "1P" + "火";
			Ray();
			audio.PlayOneShot(FireSE);
			Attack = false;
			}
		else if ( FingerCount == 2) {
			guiText.text = "1P" + "氷";
			Ray();
			audio.PlayOneShot(IceSE);
			Attack = false;
			}
		else if ( FingerCount ==1) {
			guiText.text = "1P" + "雷";
			Ray();
			audio.PlayOneShot(SanderSE);
			Attack = false;
			}
		}
		if(FingerCount == 0 ) {
		guiText.text = "1P" + "無";
		Attack = true;
		}


		firsthand.x = firstHand.PalmPosition.x + 500;
		firsthand.y = -firstHand.PalmPosition.y + 400;
		
		GUI.DrawTexture (new Rect (firsthand.x - (OnePlayercrosshairImage.width / 2),
		                           firsthand.y + (OnePlayercrosshairImage.height / 2),
		                           OnePlayercrosshairImage.width,
		                           OnePlayercrosshairImage.height), OnePlayercrosshairImage);		

			}

}
}
