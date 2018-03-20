﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	public GameObject player;
	public float timeSpent = 0f;

	bool paused = false;
	bool playerInteractive = false;

	public bool GetPause ()
	{
		return paused;
	}

	public void SetPause (bool p)
	{
		paused = p;
		Time.timeScale = paused ? 0 : 1;
	}

	public bool IsPlayable ()
	{
		return !paused && playerInteractive;
	}

	void Awake ()
	{
		GlobalGame.Get ().currentLevel = this;
	}

	void Start ()
	{
		var camera = Camera.main.gameObject;
		iTween.ValueTo (camera, iTween.Hash ("from", 15f, "to", 5f, "time", 3f, "onupdate", "CameraZoom", "easetype", "easeInQuad", "delay", 1f));
		iTween.MoveTo (camera, iTween.Hash ("y", -5f, "easeType", "easeInQuad", "time", 3f, "delay", 1f));
		iTween.ShakePosition (camera, iTween.Hash ("amount", new Vector3 (0.2f, 0.2f, 0f), "delay", 4f, "time", 2f, "oncomplete", "LaunchPlayer"));
	}

	void CameraZoom (float val)
	{
		Camera.main.orthographicSize = val;
	}

	void LaunchPlayer ()
	{
		player.GetComponent<PlayerMotion> ().Launch ();
		playerInteractive = true;
	}

	public void PlayerDie ()
	{
		Invoke ("RestartScene", 2f);
	}

	public void PlayerWin ()
	{
		// TODO(yutian): Display win screen.
	}

	void RestartScene ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}