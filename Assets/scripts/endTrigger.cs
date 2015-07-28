using UnityEngine;
using System.Collections;

public class endTrigger : MonoBehaviour
{

	//OKAY, here's what this needs to do.
	//Needs to check if hasFallen, which is in playerControls, is true or false.
	//Needs to display new text and/or trigger an audio file to play when the player collides with the trigger.
	//Depending on whether or not hasFallen is true or false, we need to show different texts and/or play different audio.


	public AudioSource failureDialogue;
	public AudioSource successDialogue;
	private string fallenMessage;

	//When the player enters, check if they have fallen, play dialogue based on this.
	void OnTriggerEnter (Collider other)
	{
		if (GameObject.FindWithTag ("Player").GetComponent<playerControls> ().hasFallen) {
			failureDialogue.Play ();
		} else {
			successDialogue.Play ();

		}
		//Debug.Log ("We have trigged");
	}

		

	//Display whether or not the player has fallen.
	void OnGUI ()
	{
		GUI.color = Color.black;
		GUI.Label (new Rect (820, 550, 300, 300), fallenMessage);
	}


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Using FindTag, we can find "Player", a tag we assigned at the top of the inspector of the playerCube object
		//This line will check if one of the components of playerCube, hasFallen, is true

		if (GameObject.FindWithTag ("Player").GetComponent<playerControls> ().hasFallen) {
			fallenMessage = "Fell! 'K' to restart";
			//If you need to debug, use this: Debug.Log ("You fell! Press K to restart, or practice the level anyway.");
		}
		
		//This line will check if one of the components of playerCube, hasFallen, is false.
		//the ! means "not", therefore, this checks for false instead of true.
		if (!GameObject.FindWithTag ("Player").GetComponent<playerControls> ().hasFallen) {
			fallenMessage = "Has not fallen!";
		}
	}
}
