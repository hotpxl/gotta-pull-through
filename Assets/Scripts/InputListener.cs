using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
	public GameObject[] planets;
	private static float overlapRadius = 0.2f;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			var hits = Physics2D.OverlapPointAll (mousePosition, Physics2D.DefaultRaycastLayers, 0f);
			foreach (var hit in hits) {
				if (hit.gameObject.tag == "Planet") {
					// TODO(yutian): Do we want the gravity cloud to also be part of the planet?
					Destroy (hit.gameObject);
					return;
				}
			}
			var existing = Physics2D.OverlapCircle (mousePosition, overlapRadius);
			if (!existing) {
				Instantiate (planets [Random.Range (0, planets.Length)], (Vector2)mousePosition, Quaternion.identity);
				return;
			}
		}
	}
}
