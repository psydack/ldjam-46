using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameController : Singleton<GameController>
{

	public Tobias tobias;
	public MegaPlayerControl playerControl;
	public SimpleUIFade uiFade;

	public SimpleUIFade loseCanvas;
	public SimpleUIFade winCanvas;

	public GameObject keyPrefab;

	public CinemachineVirtualCamera camera;
	CinemachineBasicMultiChannelPerlin cameraNoise;

	private void Awake()
	{
		uiFade.gameObject.SetActive(true);
		loseCanvas.gameObject.SetActive(true);
		winCanvas.gameObject.SetActive(true);
		cameraNoise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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

	public void GenerateKeyFade(KeyCode key)
	{
		var instance = GameObject.Instantiate(keyPrefab);

		float posZ = Random.Range(-1f, 1f);
		//float posY = Random.Range(1.5f, 3f);

		var position = new Vector3(instance.transform.position.x, instance.transform.position.y, posZ);

		instance.transform.position = position;

		Shake();
		instance.GetComponent<SimpleKeyFade>().SetChar(Helpers.KeyToCaption(key)); ;
	}


	public void Shake()
	{
		cameraNoise.m_AmplitudeGain = 2;
		cameraNoise.m_FrequencyGain = 2;
	}
}
