﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotion : MonoBehaviour
{
	public float speed;
	public GameObject explosion;
	public Game game;
	private Rigidbody2D rigidbodyComponent;

	void Start ()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var rotation = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		transform.rotation = rotation;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		var input = Input.GetAxis ("Vertical");
		rigidbodyComponent.AddForce (transform.up * speed * input);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		var contact = (other.transform.position + transform.position) / 2;
		Instantiate (explosion, contact, Quaternion.identity);
		game.RestartLevel (2f);
		Destroy (gameObject);
	}
}
