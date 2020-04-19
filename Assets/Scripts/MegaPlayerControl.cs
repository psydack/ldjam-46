using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaPlayerControl : MonoBehaviour
{

	private Vector3 startPosition; // initial position (up)
	private Vector3 finalPosition = new Vector3(0, 2.18f, 0); // final position (pressed)

	public float playerForce = 1.1f;
	public float pressForce = 1;

	public bool started = false;

	private void Start()
	{
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (started)
		{
			var position = transform.position;

			// currently press power
			var finalPower = pressForce;

			// player action
			if (Input.anyKeyDown)
			{
				finalPower -= playerForce;
			}

			// interpol
			position.y -= finalPower * Time.deltaTime;

			// clamp
			if (position.y >= startPosition.y) position.y = startPosition.y;
			
			// apply results on transform
			transform.position = position;
		}
	}
}
