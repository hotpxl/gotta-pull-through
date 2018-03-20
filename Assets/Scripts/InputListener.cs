using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputListener : MonoBehaviour
{
	public GameObject[] planets;
	public GameObject explosion;
	private static float overlapRadius = 0.5f;
	private static float blastRadius = 2.0f;
	private static float blastImpulse = 2f;


	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject () || !GlobalGame.Get ().IsPlayable ()) {
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
			Instantiate (planets [Random.Range (0, planets.Length)], (Vector2)mousePosition, Quaternion.identity);
		}
	}
}
