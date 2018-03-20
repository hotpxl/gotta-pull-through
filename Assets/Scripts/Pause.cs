using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	private bool paused = false;
	private Image imageComponent;

	public Sprite pauseSprite;
	public Sprite playSprite;
	public GameObject pauseMenu;
	
	void Start ()
	{
		imageComponent = GetComponent<Image> ();
		imageComponent.sprite = pauseSprite;
	}

	public void TogglePause ()
	{
		paused = !paused;
		pauseMenu.SetActive (paused);
		imageComponent.sprite = paused ? playSprite : pauseSprite;
		Time.timeScale = paused ? 0 : 1;
		GlobalGame.Get ().SetPause (paused);
	}
}
