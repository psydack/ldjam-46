using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUIFade : MonoBehaviour
{
	Image image;

	private void Awake()
	{
		image = GetComponent<Image>();
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
		var color = Color.black;
		color.a = 0;
		image.color = color;
		while (color.a < 1)
		{
			color.a += Time.deltaTime * speed;
			image.color = color;
			yield return null;
		}
		color.a = 1;
		image.color = color;
		image.raycastTarget = true;
	}

	IEnumerator FadeOut(float speed)
	{
		var color = Color.black;
		color.a = 1;
		image.color = color;
		while (color.a > 0)
		{
			color.a -= Time.deltaTime * speed;
			image.color = color;
			yield return null;
		}
		color.a = 0;
		image.color = color;
		image.raycastTarget = false;
	}

}
