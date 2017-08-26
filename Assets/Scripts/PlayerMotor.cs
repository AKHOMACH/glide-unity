using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour 
{
	private CharacterController controller;

	public float baseSpeed = 10.0f;
	public float rotSpeedX = 3.0f;
	public float rotSpeedY = 1.5f;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		// Give player forward player velocity
		Vector3 moveVector = transform.forward * baseSpeed;

		// Gather player's input
		Vector3 inputs = Manager.Instance.GetPlayerInput();

		// Get the delta direction
		Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
		Vector3 pitch = inputs.y * transform.up * rotSpeedY * Time.deltaTime;
		Vector3 dir = yaw + pitch;

		// Make sure we are limit player from doing a loop
		float maxX = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;

		// If has not going to far up/down, add the direction to the moveVector
		if (maxX < 90 && maxX > 70 || maxX > 270 && maxX < 290)
		{
			// Too far, don't do anything
		}
		else
		{
			// Add the direction to the current move
			moveVector += dir;
			
			// Have the player face where he is goind
			transform.rotation = Quaternion.LookRotation(moveVector);
		}

		// move him!
		controller.Move(moveVector * Time.deltaTime);
	}
}
