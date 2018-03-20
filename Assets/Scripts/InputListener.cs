using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputListener : MonoBehaviour
{
	static float overlapRadius = 0.5f;
	static float blastRadius = 2.0f;
	static float blastImpulse = 2f;
	static int planetCount = 4;
	GameObject explosion;
	GameObject[] planets = new GameObject[planetCount];

	void Start ()
	{
		explosion = Resources.Load<GameObject> ("Explosion");
		for (int i = 0; i < planetCount; ++i) {
			planets [i] = Resources.Load<GameObject> ("Planet" + (i + 1));
		}
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject () || EventSystem.current.IsPointerOverGameObject (0) || !GlobalGame.Get ().currentLevel.IsPlayable ()) {
				return;
			}
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePosition.z = 0;

			var hits = Physics2D.OverlapPointAll (mousePosition);
			foreach (var hit in hits) {
				if (hit.gameObject.tag == "Planet") {
					Destroy (hit.transform.parent.gameObject);
					Instantiate (explosion, mousePosition, Quaternion.identity);
					var blasts = Physics2D.OverlapCircleAll (hit.transform.position, blastRadius);
					foreach (var blast in blasts) {
						if (blast.gameObject.tag == "Player") {
							var direction = blast.transform.position - hit.transform.position;
							direction.Normalize ();
							blast.GetComponent<Rigidbody2D> ().AddForce (blastImpulse * direction, ForceMode2D.Impulse);
							break;
						}
					}
					return;
				}
			}
			hits = Physics2D.OverlapCircleAll (mousePosition, overlapRadius);
			foreach (var hit in hits) {
				if (hit.gameObject.tag == "Planet" || hit.gameObject.tag == "Meteroid") {
					return;
				}
			}
			var newPlanet = Instantiate (planets [Random.Range (0, planets.Length)], (Vector2)mousePosition, Quaternion.identity);
			iTween.ScaleFrom (newPlanet, iTween.Hash ("scale", new Vector3 (0.1f, 0.1f, 1f), "time", 0.3f));
		}
	}
}
