using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotion : MonoBehaviour
{
	public float speed;

	Rigidbody2D rigidbodyComponent;
	bool started = false;

	void Start ()
	{
		rigidbodyComponent = GetComponent<Rigidbody2D> ();
	}

	public void Launch ()
	{
		// TODO(yutian): Play animation.
		rigidbodyComponent.AddForce (new Vector2 (0, 1), ForceMode2D.Impulse);
		started = true;
	}

	void FixedUpdate ()
	{
		if (started) {
			var velocity = rigidbodyComponent.velocity;
			// 90 degrees to offset the rotation of the sprite itself.
			transform.rotation = Quaternion.AngleAxis (Mathf.Atan2 (velocity.y, velocity.x) * Mathf.Rad2Deg - 90, Vector3.forward);
		}
	}
}
