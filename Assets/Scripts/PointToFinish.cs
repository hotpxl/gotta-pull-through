using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToFinish : MonoBehaviour
{
	public GameObject target;
	public float distance = 1f;

	void Update ()
	{
		var direction = target.transform.position - transform.parent.position;
		direction.Normalize ();
		direction *= distance;
		transform.position = transform.parent.position + direction;
		// 90 degrees to offset the rotation of the sprite itself.
		transform.rotation = Quaternion.AngleAxis (Vector3.SignedAngle (Vector3.up, direction, Vector3.forward) + 90, Vector3.forward);
	}
}
