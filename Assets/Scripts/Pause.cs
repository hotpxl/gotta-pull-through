using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	private Image imageComponent;

	public Sprite pauseSprite;
	public Sprite playSprite;
	public GameObject pauseMenu;

	void Start ()
	{
		imageComponent = GetComponent<Image> ();
		imageComponent.sprite = pauseSprite;
		GlobalGame.Get ().currentLevel.paused = false;
		
	}

	public void TogglePause ()
	{
		var level = GlobalGame.Get ().currentLevel;
		level.paused = !level.paused;
		pauseMenu.SetActive (level.paused);
		imageComponent.sprite = level.paused ? playSprite : pauseSprite;
		Time.timeScale = level.paused ? 0 : 1;
	}
}
