using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressControl : MonoBehaviour
{

	private Vector3 startPosition; // initial position (up)
	private Vector3 finalPosition = new Vector3(0, 2.18f, 0); // final position (pressed)

	public float PressRate = 5f; // time waiting until press

	public float PressVelocity = 1; // how long to down
	public float ReleaseVelocity = 1; // how long to up

	public float PressDelay = 5f; // time waiting until goes up
	public float ReleaseDelay = 5f; // time waiting until goes up

	private float timeToAct = 0; // internal counter to next action
	private bool pressing = false; // is going up or down
	private bool canAct = true;

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		startPosition = transform.position; // save to us or position
	}


	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		if (canAct)
		{
			if (timeToAct > PressRate)
			{
				if (!pressing)
				{
					// press
					pressing = true;
					timeToAct = 0;
					StartCoroutine(Press()); // do action
				}
				else
				{
					// release
					pressing = false;
					timeToAct = 0;
					StartCoroutine(Release()); // do action
				}
			}
			else
			{
				timeToAct += Time.deltaTime; // increment and try next frame
			}

		}

	}

	/// <summary>
	/// Do press
	/// </summary>
	/// <returns></returns>
	IEnumerator Press()
	{
		return Act(finalPosition, ReleaseDelay, PressVelocity);
	}

	/// <summary>
	/// Release (up)
	/// </summary>
	/// <returns></returns>
	IEnumerator Release()
	{
		return Act(startPosition, PressDelay, ReleaseVelocity);
	}

	IEnumerator Act(Vector3 goPosition, float delayTime, float velocity)
	{
		canAct = false;
		var currentPos = transform.position;
		var t = 0f;
		while (t < 1)
		{
			t += Time.deltaTime / velocity;
			transform.position = Vector3.Lerp(currentPos, goPosition, t);
			yield return null;
		}
		transform.position = goPosition;
		yield return new WaitForSeconds(delayTime);
		canAct = true;
	}


}
