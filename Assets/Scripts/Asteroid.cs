using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	GameObject explosion;

	void Start ()
	{
		explosion = Resources.Load<GameObject> ("Explosion");
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			var contact = other.bounds.ClosestPoint (transform.position);
			Instantiate (explosion, contact, Quaternion.identity);
			GlobalGame.Get ().currentLevel.PlayerDie ();
			Destroy (other.gameObject);
		}
	}
}
