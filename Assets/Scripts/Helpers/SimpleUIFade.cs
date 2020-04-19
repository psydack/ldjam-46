using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUIFade : MonoBehaviour
{
	CanvasGroup canvasGroup;

	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void FadeIn()
	{
		StartCoroutine(FadeIn(1));
	}

	public void FadeOut()
	{
		StartCoroutine(FadeOut(1));
	}

	IEnumerator FadeIn(float speed)
	{
		canvasGroup.blocksRaycasts = true;
		float alpha = 0;
		while (alpha < 1)
		{
			alpha += Time.deltaTime * speed;
			canvasGroup.alpha = alpha;
			yield return null;
		}
		alpha = 1;
		canvasGroup.alpha = alpha;
	}

	IEnumerator FadeOut(float speed)
	{
		float alpha = 1;
		while (alpha > 0)
		{
			alpha -= Time.deltaTime * speed;
			canvasGroup.alpha = alpha;
			yield return null;
		}
		alpha = 0;
		canvasGroup.alpha = alpha;
		canvasGroup.blocksRaycasts = false;
	}

}
