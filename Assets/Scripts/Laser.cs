using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
	private LineRenderer lr;

	void Start()
	{
		lr = GetComponent<LineRenderer>();
	}

	void Update()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position, transform.forward, out hit))
		{
			if(hit.collider)
			{
				lr.SetPosition(1, new Vector3(0,0,hit.distance));
			}
		}else{
			lr.SetPosition(1, new Vector3(0,0,5000));
		}
	}
}
