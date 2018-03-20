using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyRotating : MonoBehaviour
{
	public float rotateSpeed = 2.0f;

	void Update ()
	{
		transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);	
	}
}
