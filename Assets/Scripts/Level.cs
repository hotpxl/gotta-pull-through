using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	public float timeSpent = 0f;

	bool paused = false;
	bool playerInteractive = false;
	GameObject player;
	GameObject winMenu;
	GameObject pauseButton;
	GameObject continueButton;
	AudioClip rocketStart;

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
		player = GameObject.Find ("Player");
		winMenu = GameObject.Find ("Menus").transform.Find ("Win Menu").gameObject;
		pauseButton = GameObject.Find ("Menus").transform.Find ("Pause Button").gameObject;
		continueButton = winMenu.transform.Find ("Continue Button").gameObject;
		rocketStart = Resources.Load<AudioClip> ("Sounds/RocketLaunch");
		SetPause (false);
		SetDeathAndLevelPanel ();
		var camera = gameObject;
		iTween.ValueTo (camera, iTween.Hash ("from", Camera.main.orthographicSize, "to", 5f, "time", 3f, "onupdate", "CameraZoom", "easetype", "easeInQuad", "delay", 1f));
		iTween.MoveTo (camera, iTween.Hash ("position", new Vector3 (player.transform.position.x, player.transform.position.y, -10), "easeType", "easeInQuad", "time", 3f, "delay", 1f, "oncomplete", "PlayRocketLaunch"));
		iTween.RotateTo (camera, iTween.Hash ("z", 0f, "easeType", "easeInQuad", "time", 3f, "delay", 1f));
		iTween.ShakePosition (camera, iTween.Hash ("amount", new Vector3 (0.1f, 0.1f, 0f), "delay", 4f, "time", 1.5f, "oncomplete", "LaunchPlayer"));
	}

	void CameraZoom (float val)
	{
		Camera.main.orthographicSize = val;
	}

	void LaunchPlayer ()
	{
		player.GetComponent<PlayerMotion> ().Launch ();
		playerInteractive = true;
		pauseButton.SetActive (true);
	}

	public void PlayerDie ()
	{
		Invoke ("RestartLevel", 2f);
	}

	public void PlayerWin ()
	{
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		// Fix the position of the player on finish.
		player.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		playerInteractive = false;
		pauseButton.SetActive (false);
		winMenu.SetActive (true);
		// No next level for last level.
		continueButton.SetActive (GlobalGame.Get ().levelIndex != GlobalGame.levels.Length - 1);
	}

	public void LoadNextLevel ()
	{
		SceneManager.LoadScene (GlobalGame.levels [++GlobalGame.Get ().levelIndex]);
	}

	public void RestartLevel ()
	{
		++GlobalGame.Get ().totalDeath;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void SetDeathAndLevelPanel ()
	{
		GameObject.Find ("Death Value").GetComponent<Text> ().text = GlobalGame.Get ().totalDeath.ToString ();
		GameObject.Find ("Level Value").GetComponent<Text> ().text = (GlobalGame.Get ().levelIndex + 1).ToString ();
	}

	void PlayRocketLaunch ()
	{
		player.GetComponent<AudioSource> ().PlayOneShot (rocketStart);
	}
}
