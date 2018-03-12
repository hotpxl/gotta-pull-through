using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
	public float gravityConstant;

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			var direction = transform.position - other.transform.position;
			var distance = direction.magnitude;
			if (0 < distance) {
				direction.Normalize ();
				other.GetComponent<Rigidbody2D> ().AddForce (direction / distance / distance);
			}
		}
	}
}
