using UnityEngine;
using System.Collections;

public class jumpTrigger : MonoBehaviour
{


	public AudioSource jumpDialogue;

	//Play jumpDialogue AudioSource after colliding with collider in Unity that has this script attached.
	void OnTriggerEnter (Collider other)
	{
		jumpDialogue.Play ();
	}


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
