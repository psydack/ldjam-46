using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameController : MonoBehaviour
{

	public Tobias tobias;
	public MegaPlayerControl playerControl;
	public SimpleUIFade uiFade;

	public SimpleUIFade loseCanvas;
	public SimpleUIFade winCanvas;

	public GameObject keyPrefab;

	public CinemachineBrain cameraBrain;
	public CinemachineVirtualCamera camera1;
	public CinemachineVirtualCamera camera2;
	public CinemachineVirtualCamera camera3;

	new CinemachineVirtualCamera camera;
	CinemachineBasicMultiChannelPerlin cameraNoise;

	public bool finished;

	public static GameController Instance;

	private void Awake()
	{
		Instance = this;

		uiFade.gameObject.SetActive(true);
		loseCanvas.gameObject.SetActive(true);
		winCanvas.gameObject.SetActive(true);

		camera = camera1;
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
		if (!finished)
		{
			finished = true;
			loseCanvas.FadeIn();
			loseCanvas.GetComponent<CanvasGroup>().interactable = true;
		}
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

		var position = new Vector3(instance.transform.position.x, instance.transform.position.y, posZ);

		instance.transform.position = position;

		StopAllCoroutines();
		StartCoroutine(Shake());

		instance.GetComponent<SimpleKeyFade>().SetChar(Helpers.KeyToCaption(key)); ;
	}


	public IEnumerator Shake()
	{
		cameraNoise.m_AmplitudeGain = 1;
		cameraNoise.m_FrequencyGain = 1;
		yield return new WaitForSeconds(.25f);
		cameraNoise.m_AmplitudeGain = 0;
		cameraNoise.m_FrequencyGain = 0;
	}

	public void ChangeCamera(int index)
	{
		if (index == 1 && !camera1.enabled)
		{
			camera.enabled = false;
			camera = camera1;
			camera.enabled = true;
			cameraNoise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		}
		else if (index == 2 && !camera2.enabled)
		{
			camera.enabled = false;
			camera = camera2;
			camera.enabled = true;
			cameraNoise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		}
		else if (index == 3 && !camera3.enabled)
		{
			camera.enabled = false;
			camera = camera3;
			camera.enabled = true;
			cameraNoise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		}
	}
}
