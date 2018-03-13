using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
	public GameObject[] planets;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePosition.z = 0f;
			Instantiate (planets[Random.Range(0, planets.Length)], mousePosition, Quaternion.identity);
		}
	}
}