using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{

	public Tobias tobias;
	public MegaPlayerControl playerControl;
	public SimpleUIFade uiFade;

	public SimpleUIFade loseCanvas;
	public SimpleUIFade winCanvas;

	private void Awake()
	{
		uiFade.gameObject.SetActive(true);
		loseCanvas.gameObject.SetActive(true);
		winCanvas.gameObject.SetActive(true);
	}

	private void Start()
	{
		uiFade.FadeOut();
	}

	public void StartGame()
	{
		playerControl.StartTheGame();
	}
	public void RestartGame()
	{
		SimpleLoadScene.LoadSceneS(SceneManager.GetActiveScene().name);
	}
	public void LoseGame()
	{
		loseCanvas.FadeIn();
		loseCanvas.GetComponent<CanvasGroup>().interactable = true;
	}

	public void WinGame()
	{
		winCanvas.FadeIn();
		winCanvas.GetComponent<CanvasGroup>().interactable = true;
	}
}
