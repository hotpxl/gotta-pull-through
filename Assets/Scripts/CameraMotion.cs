using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
	public GameObject player;
	public float smoothTime;
	public Vector3 offset;
	public Vector2 bottomLeft;
	public Vector2 topRight;
	public float border;

	Vector3 velocity = Vector3.zero;
	Camera cameraComponent;
	bool startFollowing = false;

	void Start ()
	{
		cameraComponent = GetComponent<Camera> ();
		iTween.ValueTo (gameObject, iTween.Hash ("from", 15f, "to", 5f, "time", 3f, "onupdate", "CameraZoom", "easetype", "easeInQuad", "delay", 1f));
		iTween.MoveTo (gameObject, iTween.Hash ("y", -5f, "easeType", "easeInQuad", "time", 3f, "delay", 1f));
		iTween.ShakePosition (gameObject, iTween.Hash ("amount", new Vector3 (0.2f, 0.2f, 0f), "delay", 4f, "time", 2f, "oncomplete", "LaunchPlayer"));
	}

	void FixedUpdate ()
	{
		if (startFollowing && player != null) {
			var desired = player.transform.position + offset;
			var halfHeight = GetComponent<Camera> ().orthographicSize;
			var halfWidth = halfHeight / Screen.height * Screen.width;
			desired.x = Mathf.Min (topRight.x + border - halfWidth, Mathf.Max (bottomLeft.x - border + halfWidth, desired.x));
			desired.y = Mathf.Min (topRight.y + border - halfHeight, Mathf.Max (bottomLeft.y - border + halfHeight, desired.y));
			transform.position = Vector3.SmoothDamp (transform.position, desired, ref velocity, smoothTime);
		}
	}

	void CameraZoom (float val)
	{
		cameraComponent.orthographicSize = val;
	}

	void LaunchPlayer ()
	{
		player.GetComponent<PlayerMotion> ().Launch ();
		startFollowing = true;
	}
}