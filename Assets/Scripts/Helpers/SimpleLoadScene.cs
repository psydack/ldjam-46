using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLoadScene : MonoBehaviour
{

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);
	}
	public void LoadSceneAsync(string name)
	{
		SceneManager.LoadSceneAsync(name);
	}

	public void LoadSceneAsyncAfterHalfSecond(string name)
	{
		StartCoroutine(LoadSceneAfterSeconds(name, 1.25f));
	}

	IEnumerator LoadSceneAfterSeconds(string name, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		LoadSceneAsync(name);
	}

	public static void LoadSceneS(string name)
	{
		SceneManager.LoadScene(name);
	}
}
