using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MegaPlayerControl : MonoBehaviour
{

	private Vector3 startPosition; // initial position (up)
	private Vector3 finalPosition = new Vector3(0, 2.18f, 0); // final position (pressed)

	public float playerForce = 1.1f;
	public float pressForce = 1;
	public float Speed = 1;

	public bool started = false;

	private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

	private void Start()
	{
		startPosition = transform.position;
		finalPosition -= startPosition;
	}

	public void StartTheGame()
	{
		started = true;
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < keyCodes.Length; i++)
		{
			KeyCode keyCode = (KeyCode)keyCodes.GetValue(i);
			if (Input.GetKeyDown(keyCode))
			{
				GameController.Instance.GenerateKeyFade(keyCode);
			}
		}
		if (started)
		{
			var position = transform.position;

			// currently press power
			var finalPower = pressForce;

			// player action
			if (Input.anyKeyDown)
			{
				for (int i = 0; i < keyCodes.Length; i++)
				{
					KeyCode keyCode = (KeyCode)keyCodes.GetValue(i);
					if (Input.GetKeyDown(keyCode))
					{
						finalPower -= playerForce;
						GameController.Instance.GenerateKeyFade(keyCode);
					}
				}
			}

			// interpol
			position.y -= finalPower * Time.deltaTime * Speed;

			// clamp
			//position.y = Mathf.Clamp(finalPosition.y, startPosition.y, position.y);
			if (position.y > startPosition.y) position.y = startPosition.y;
			else if (position.y < finalPosition.y) position.y = finalPosition.y;

			// apply results on transform
			transform.position = position;
		}
	}

}
