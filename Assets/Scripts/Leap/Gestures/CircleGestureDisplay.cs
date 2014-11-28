using UnityEngine;
using System.Collections;
using Leap;

public class CircleGestureDisplay : GestureDisplay {
	
	private CircleGesture _circleGesture;

	public CircleGesture circleGesture
	{
		get
		{
			return _circleGesture;
		}
		
		set
		{
			_circleGesture = value;
			gesture = value;
		}
	}
	
	public override void Start()
	{
		if (circleGesture == null)
			Destroy (this);
        
	}
	
	public override void Update()
	{
		base.Update();
		
		if (circleGesture == null)
			Destroy(gameObject);
		
		transform.position = circleGesture.Center.ToUnityTranslated();
		
		
		
	}
		
}
