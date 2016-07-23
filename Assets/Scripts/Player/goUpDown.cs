using UnityEngine;
using System.Collections;

public class goUpDown : MonoBehaviour {

	private float forwardSpeed = 6f;

	private bool moveUp;
	private bool moveDown;

	void Update()
	{
		if(moveUp && !moveDown)
			GetComponent<Rigidbody2D>().AddForce (Vector3.up * forwardSpeed);

		if(moveDown && !moveUp)
			GetComponent<Rigidbody>().AddForce (Vector3.down * forwardSpeed);
	}

	public void MoveMeUp()
	{
		moveUp = true;
	}

	public void StopMeUp()
	{
		moveUp = false;
	}

	public void MoveMeDown()
	{
		moveDown = true;
	}

	public void StopMeDown()
	{
		moveDown = false;
	}
}
