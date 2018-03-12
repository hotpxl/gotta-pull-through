using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public GameObject explosion;
	public Game game;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			var contact = other.bounds.ClosestPoint (transform.position);
			Instantiate (explosion, contact, Quaternion.identity);
			game.RestartLevel (2f);
			Destroy (other.gameObject);
		}
	}
}
