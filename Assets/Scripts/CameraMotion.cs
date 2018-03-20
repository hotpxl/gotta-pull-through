using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
	public float smoothTime;
	public Vector2 bottomLeft;
	public Vector2 topRight;
	public float border;

	static Vector3 offset = new Vector3 (0, 0, -10);
	GameObject player;

	Vector3 velocity = Vector3.zero;

	void Start ()
	{
		player = GameObject.Find ("Player");
	}

	void FixedUpdate ()
	{
		if (GlobalGame.Get ().currentLevel.IsPlayable () && player != null) {
			var desired = player.transform.position + offset;
			var halfHeight = GetComponent<Camera> ().orthographicSize;
			var halfWidth = halfHeight / Screen.height * Screen.width;
			desired.x = Mathf.Min (topRight.x + border - halfWidth, Mathf.Max (bottomLeft.x - border + halfWidth, desired.x));
			desired.y = Mathf.Min (topRight.y + border - halfHeight, Mathf.Max (bottomLeft.y - border + halfHeight, desired.y));
			transform.position = Vector3.SmoothDamp (transform.position, desired, ref velocity, smoothTime);
		}
	}
}