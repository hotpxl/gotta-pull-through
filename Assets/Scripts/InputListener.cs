using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
	public GameObject[] planets;
	private static float overlapRadius = 0.5f;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			var hits = Physics2D.OverlapPointAll (mousePosition, Physics2D.DefaultRaycastLayers, 0f);
			foreach (var hit in hits) {
				if (hit.gameObject.tag == "Planet") {
					Destroy (hit.transform.parent.gameObject);
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
