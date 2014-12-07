using UnityEngine;
using System.Collections;
using Leap;

public class LeapMove : MonoBehaviour {

	Controller controller = new Controller();
	
	public int FingerCount;
	public int HandCount;
	public GameObject[] HandObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		FingerCount = frame.Fingers.Count;
		HandCount = frame.Hands.Count;
		
		InteractionBox interactionBox = frame.InteractionBox;

    for ( int i = 0; i < HandObjects.Length; i++ ) {
      var leapHand = frame.Hands[i];
      var unityHand = HandObjects[i];
      SetVisible( unityHand, leapHand.IsValid );
      if ( leapHand.IsValid ) {
        Vector normalizedPosition = interactionBox.NormalizePoint(leapHand.PalmPosition );
        normalizedPosition *= 10;
        normalizedPosition.z = -normalizedPosition.z;
        unityHand.transform.localPosition = ToVector3( normalizedPosition );
      }
    }
  }

  void SetVisible( GameObject obj, bool visible )
  {
    foreach( Renderer component in obj.GetComponents<Renderer>() ) {
      component.enabled = visible;
    }
  }

  Vector3 ToVector3( Vector v )
  {
    return new UnityEngine.Vector3( v.x, v.y, v.z );
		
		
	
	}
}
