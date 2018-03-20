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
		GlobalGame.Get ().currentLevel.SetPause (false);
		
	}

	public void TogglePause ()
	{
		var paused = !GlobalGame.Get ().currentLevel.GetPause ();
		GlobalGame.Get ().currentLevel.SetPause (paused);
		pauseMenu.SetActive (paused);
		imageComponent.sprite = paused ? playSprite : pauseSprite;
	}
}
