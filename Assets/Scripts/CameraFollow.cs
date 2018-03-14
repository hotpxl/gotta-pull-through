using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	public float smoothTime;
	public Vector3 offset;
	private Vector3 velocity = Vector3.zero;
	public Vector2 bottomLeft;
	public Vector2 topRight;
	public float border;

	void FixedUpdate ()
	{
		if (target) {
			var desired = target.transform.position + offset;
			var halfHeight = GetComponent<Camera> ().orthographicSize;
			var halfWidth = halfHeight / Screen.height * Screen.width;
			desired.x = Mathf.Min (topRight.x + border - halfWidth, Mathf.Max (bottomLeft.x - border + halfWidth, desired.x));
			desired.y = Mathf.Min (topRight.y + border - halfHeight, Mathf.Max (bottomLeft.y - border + halfHeight, desired.y));
			transform.position = Vector3.SmoothDamp (transform.position, desired, ref velocity, smoothTime);
		}
	}
}