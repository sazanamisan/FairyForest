using UnityEngine;

/// <summary>
/// This script spins an object around two axes(yes that is the correct pural word).
/// </summary>
public class Spin : MonoBehaviour
{
	public Transform Target; //The target object

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		Target.Rotate(Vector3.up, 3, Space.World); //rotate the target object around the up axis
		Target.Rotate(Vector3.right, 2, Space.Self); //rotate the target object around the right axis
	}
}
