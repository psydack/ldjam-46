using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Tobias : MonoBehaviour
{
	public TextMeshProUGUI tobiasCountdown;
	int countdown = 30;

	// Start is called before the first frame update
	void Start()
	{
		Invoke("NextAction", 3f);
		Invoke("NextAction", 25f);
		InvokeRepeating("UpdateCountdown", 1, 1);

	}

	void UpdateCountdown()
	{
		if (countdown > 0)
		{
			countdown--;
			tobiasCountdown.SetText(countdown.ToString());
		}
	}


	public void NextAction()
	{
		GetComponent<Animator>().SetTrigger("NextAction");
	}


	public void ResetToInitialState()
	{
		GetComponent<Animator>().Rebind();
	}
}
