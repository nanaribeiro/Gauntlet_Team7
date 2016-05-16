using UnityEngine;
using System.Collections;

public class Unlockable_door : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision other)
	{
		//check if the other collider is a player
		if (other.gameObject.tag == "Player") 
		{
			//check to see if the player has a key to open the door
				//destroy this object
				//decrease player's keys by 1
		}
	}
}
