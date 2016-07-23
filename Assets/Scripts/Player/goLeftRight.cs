using UnityEngine;
using System.Collections;

public class goLeftRight : MonoBehaviour {

	private float forwardSpeed = 6f;
	private bool moveLeft;
	private bool moveRight;

	void Update()
	{
		if(moveLeft && !moveRight)
			GetComponent<Rigidbody>().AddForce (Vector3.left * forwardSpeed);

		if(moveRight && !moveLeft)
			GetComponent<Rigidbody>().AddForce (Vector3.right * forwardSpeed);
	}

	public void MoveMeLeft()
	{
		moveLeft = true;
	}

	public void StopMeLeft()
	{
		moveLeft = false;
	}

	public void MoveMeRight()
	{
		moveRight = true;
	}

	public void StopMeRight()
	{
		moveRight = false;
	}
}
