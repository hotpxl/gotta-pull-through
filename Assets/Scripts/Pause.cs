using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	GameObject pauseMenu;

	void Start ()
	{
		pauseMenu = GameObject.Find ("Canvas").transform.Find ("Pause Menu").gameObject;
		GlobalGame.Get ().currentLevel.SetPause (false);
	}

	public void TogglePause ()
	{
		var paused = !GlobalGame.Get ().currentLevel.GetPause ();
		GlobalGame.Get ().currentLevel.SetPause (paused);
		pauseMenu.SetActive (paused);
	}
}
