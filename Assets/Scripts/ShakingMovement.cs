using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingMovement : MonoBehaviour
{
	void Start ()
	{
		iTween.ShakePosition (gameObject, iTween.Hash ("amount", new Vector3 (0.1f, 0.1f, 0f), "looptype", "loop"));
	}

	void Update ()
	{
		transform.Rotate (Vector3.forward * Time.deltaTime * 20f);
	}
}
