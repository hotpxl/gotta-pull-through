using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	public GameObject pauseMenu;

	void Start ()
	{
		GlobalGame.Get ().currentLevel.SetPause (false);
	}

	public void TogglePause ()
	{
		var paused = !GlobalGame.Get ().currentLevel.GetPause ();
		GlobalGame.Get ().currentLevel.SetPause (paused);
		pauseMenu.SetActive (paused);
	}
}
