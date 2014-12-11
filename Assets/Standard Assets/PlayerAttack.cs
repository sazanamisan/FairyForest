using UnityEngine;
using System.Collections;
using Leap;

public class PlayerAttack : MonoBehaviour {


	Controller controller = new Controller();
	public int FingerCount;
	public int HandCount;
	public Texture OnePlayercrosshairImage;
	public Texture TwoPlayercrosshairImage;
	public AudioClip FireSE;
	public AudioClip IceSE;
	public AudioClip SanderSE;
	public static GameObject targetGameObject;
	private bool Attack = true;
	
	
	public UnityEngine.Vector3 firsthand = new UnityEngine.Vector3();
	public UnityEngine.Vector3 secondhand = new UnityEngine.Vector3();
		
	void Start() { 
		
		}
	
	void Update() {
	
		// マウスカーソルを削除する
    UnityEngine.Screen.showCursor = false;
    // マウスカーソルを画面内にロックする
    UnityEngine.Screen.lockCursor = true;
    if (guiText.text == "火") {
    if (Input.GetButtonDown("Fire1")) {
        audio.PlayOneShot(FireSE);
    }
    }
    else if (guiText.text == "氷") {
    if (Input.GetButtonDown("Fire1")) {
        audio.PlayOneShot(IceSE);
    }
    }
    else if (guiText.text == "雷") {
    if (Input.GetButtonDown("Fire1")) {
        audio.PlayOneShot(SanderSE);
    }
    }
	
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
		
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
		Hand secondHand = hands[1];
		HandCount = frame.Hands.Count;
		
		if (Attack == true ) {
		if (FingerCount == 5) {
			guiText.text = "火";
			Ray();
			audio.PlayOneShot(FireSE);
			Attack = false;
			}
		else if ( FingerCount == 2) {
			guiText.text = "氷";
			Ray();
			audio.PlayOneShot(IceSE);
			Attack = false;
			}
		else if ( FingerCount ==1) {
			guiText.text = "雷";
			Ray();
			audio.PlayOneShot(SanderSE);
			Attack = false;
			}
		}
		if(FingerCount == 0 ) {
		guiText.text = "無";
		Attack = true;
		}


		firsthand.x = firstHand.PalmPosition.x + 500;
		firsthand.y = -firstHand.PalmPosition.y + 600;
		secondhand.x = secondHand.PalmPosition.x + 500;
		secondhand.y = -secondHand.PalmPosition.y + 600;
		
		GUI.DrawTexture (new Rect (firsthand.x - (OnePlayercrosshairImage.width / 2),
		                           firsthand.y + (OnePlayercrosshairImage.height / 2),
		                           OnePlayercrosshairImage.width,
		                           OnePlayercrosshairImage.height), OnePlayercrosshairImage);
		                           
		GUI.DrawTexture (new Rect (secondhand.x + (TwoPlayercrosshairImage.width / 2),
		                           secondhand.y - (TwoPlayercrosshairImage.height / 2),
		                           TwoPlayercrosshairImage.width,
		                           TwoPlayercrosshairImage.height), TwoPlayercrosshairImage);		

			}

}
}
