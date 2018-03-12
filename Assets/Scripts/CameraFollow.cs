using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	public float smoothTime;
	public Vector3 offset;
	private Vector3 velocity = Vector3.zero;

	void FixedUpdate ()
	{
		var desired = target.transform.position + offset;
		transform.position = Vector3.SmoothDamp (transform.position, desired, ref velocity, smoothTime);
	}
}
