using UnityEngine;
using System.Collections;

public class CameraFollow: MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;		//for smoothening of camera movement
	Vector3 offset;

	void start(){
		offset = transform.position - target.position ;
	}

	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset - new Vector3(0, -15, 25);		//the vector was added because the camera was coincidoing with the player
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);		//smooth movement from current position to final position
	}

}
