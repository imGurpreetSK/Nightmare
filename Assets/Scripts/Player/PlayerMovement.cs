using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;
	int floorMask;						//for ray collisions onto the floor we created earlier
	float camRayLength = 100f;
	public float tilt;
	private Vector3 touchOrigin = -Vector3.one; //Used to store location of screen touch origin for mobile controls.

	public Boundary boundary;

	void Awake(){						//good for setting up references		MONOBEHAVIOR FUNCTIONS, CALLED AUTOMATICALLY
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}

	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, zMin, zMax;
	}

	void FixedUpdate(){					//runs with physics body, rigidbody attached.		MONOBEHAVIOR FUNCTIONS, CALLED AUTOMATICALLY
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		//call created function
		Move(h,v);
		Turning ();
		Animating (h, v);

		/*
		Vector3 movement = new Vector3 (h, 0.0f, v);
		playerRigidBody.velocity = movement * speed;

		playerRigidBody.position = new Vector3 
			(
				Mathf.Clamp (playerRigidBody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (playerRigidBody.position.z, boundary.zMin, boundary.zMax)
			);

		playerRigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, playerRigidBody.velocity.x * -tilt);
		*/

	}

	void Move(float h, float v){

		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;		//make unit vector for direction * multiply by our speed * update every second, not every frame
		playerRigidBody.MovePosition(movement + transform.position);

	}

	void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {		//check for ray collision
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);	//store rotation
			playerRigidBody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v){
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}

}
