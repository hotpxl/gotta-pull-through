﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
	public float gravityConstant = 1.0f;

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			var direction = transform.position - other.transform.position;
			var distance = direction.magnitude;
			if (0 < distance) {
				distance = Mathf.Max (distance, 0.1f);
				direction.Normalize ();
				other.GetComponent<Rigidbody2D> ().AddForce (gravityConstant * direction / distance / distance);
			}
		}
	}
}
