using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleKeyFade : MonoBehaviour
{

	public void SetChar(string keyChar)
	{
		GetComponent<TextMeshPro>().SetText(keyChar);
	}

	public void DestroyMe()
	{
		Destroy(gameObject);
	}
}
