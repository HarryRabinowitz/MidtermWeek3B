using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour
{

	//To check if you've fallen in the course
	public bool hasFallen = false;

	//Control floats
	public float speed = 200f;
	public float turnSpeed = 200f;
	public float balance = 50f;
	public GameObject playerBox;
	private string displayControls;


	// Use this for initialization
	void Start ()
	{
		//	displayControls = "Controls: W+A, accelaration. A+D, turning, Q+E, balancing";
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

	
		//Controls!
		float x = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
		float z = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float y = Input.GetAxis ("Balance") * balance * Time.deltaTime; 
			

		//Connecting controls to Rigidbody
		Rigidbody rbody = GetComponent<Rigidbody> ();
		rbody.AddRelativeForce (0f, 0f, z); //Forward and backward speed, as connected to float z GetAxis Vetical
		rbody.transform.Rotate (0f, x, 0f); //For turning, as connected to the float x on GetAxis Horizontal
		rbody.transform.Rotate (0f, 0f, y); //For balance, as connected to the float y on GetAxis Balance, which I made.


		//This is if the player box collider hits past a certain Z rotation, AKA hits the floor. This sets hasFallen to true!
		if (playerBox.transform.eulerAngles.z > (82f) && playerBox.transform.eulerAngles.z < (275f)) {
			hasFallen = true;
			//If you need to check in Debug, use this: Debug.Log ("You fell!");
		}

		//This is to reset position, which takes you to the start and cancels all velocities so you start stopped.
		//Also switches hasFallen back to false, since you are restarting.
		if (Input.GetKeyDown (KeyCode.K)) {
			rbody.transform.position = new Vector3 (30f, 140f, -50f);
			rbody.transform.eulerAngles = new Vector3 (0f, 1.5f, 0.4f);
			rbody.velocity = new Vector3 (0f, 0f, 0f);
			rbody.angularVelocity = new Vector3 (0f, 0f, 0f);
			hasFallen = false;
		}

	}
	
}


//Attempt to replace trigger with position checker, but cannot have greater than with a Vector 3, apparently.
//	if (playerBox.transform.position >= new Vector3 (0f, -10f, 539f)  && hasFallen == false)  {
//		fallMessage = "The instructor said I couldn't get on the skilift unless I did the hill without falling." +
//			"and...well, I fell. Better try again.";
//	}

//Attempt to add a jump, bad idea
//	if (Input.GetKeyDown (KeyCode.Space) ) {
//		rbody.AddRelativeForce (0f, jump, 0f);
//	}






