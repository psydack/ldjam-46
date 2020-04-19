using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{

	public Tobias tobias;
	public MegaPlayerControl playerControl;
	public SimpleUIFade uiFade;

	private void Awake()
	{
		uiFade.gameObject.SetActive(true);
	}

	private void Start()
	{
		uiFade.FadeOut();
	}

	public void StartGame()
	{
		playerControl.StartTheGame();
	}

	public void EndGame()
	{
		uiFade.FadeIn();
	}

	public void ResetGame()
	{
		tobias.ResetToInitialState();
		playerControl.ResetToInitialState();
		uiFade.FadeIn();
	}
}
