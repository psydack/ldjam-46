using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomTip : MonoBehaviour
{
	public string[] tips;

	// Start is called before the first frame update
	void Start()
	{
		GetComponent<TextMeshProUGUI>().SetText("TIP: " + tips[Random.Range(0, tips.Length)]);
	}

}
