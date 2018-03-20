using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotion : MonoBehaviour
{
	public float speed;

	Rigidbody2D rigidbodyComponent;

	void Start ()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D> ();
	}

	public void Launch ()
	{
		rigidbodyComponent.AddForce (new Vector2 (0, 1), ForceMode2D.Impulse);
	}

	void FixedUpdate ()
	{
		var velocity = rigidbodyComponent.velocity;
		if (0 < velocity.magnitude) {
			// 90 degrees to offset the rotation of the sprite itself.
			transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (velocity.y, velocity.x) * Mathf.Rad2Deg - 90, Vector3.forward);
		}
	}
}
