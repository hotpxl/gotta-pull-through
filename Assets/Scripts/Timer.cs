using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private Text textComponent;
	private float currentTime = 0f;

	void Start ()
	{
		textComponent = GetComponent<Text> ();
	}

	void Update ()
	{
		currentTime += Time.deltaTime;
		textComponent.text = Mathf.RoundToInt (currentTime).ToString ();
	}
}
