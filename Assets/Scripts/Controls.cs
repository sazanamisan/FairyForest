using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
	public int speed;
	public float friction;
	public float lerpSpeed;

	private float xDeg;
	private float yDeg;
	private Quaternion fromRotation;
	private Quaternion toRotation;

	void Update()
	{
			xDeg += Input.GetAxis("Horizontal") * speed * friction;

			fromRotation = transform.rotation;
			toRotation = Quaternion.Euler(0,xDeg,0);

			transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime * lerpSpeed);
	}
}
