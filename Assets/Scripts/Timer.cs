using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	Text textComponent;

	void Start ()
	{
		textComponent = GetComponent<Text> ();
		textComponent.text = "0";
	}

	void Update ()
	{
		var level = GlobalGame.Get ().currentLevel;
		if (level.IsPlayable ()) {
			level.timeSpent += Time.deltaTime;
			textComponent.text = Mathf.RoundToInt (level.timeSpent).ToString ();
		}
	}
}
