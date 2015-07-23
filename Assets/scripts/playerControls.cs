using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {


	public float speed = 200f;
	public float turnSpeed = 200f;
	public float balance = 50f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			
			float x = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
			float z = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			float y = Input.GetAxis ("Balance") * balance * Time.deltaTime; 
			Rigidbody rbody = GetComponent<Rigidbody>();
		rbody.AddRelativeForce (0f, 0f, z ) ;
			//rbody.AddRelativeForce (x, 0f, 0f ); 
		rbody.transform.Rotate (0f, x, 0f);
		rbody.transform.Rotate (0f, 0f, y);
	}

}
