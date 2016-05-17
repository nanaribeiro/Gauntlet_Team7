using UnityEngine;
using System.Collections;

//script by Colby

public class Unlockable_door : MonoBehaviour {

	void OnCollisionStay(Collision other)
	{
		//check if the other collider is a player
		if (other.gameObject.tag == "Player") 
		{
			//check to see if the player has a key to open the door
			if(other.gameObject.GetComponent<Player>().key > 0)
			{
				//destroy this object
				Destroy(gameObject);
				//decrease player's keys by 1
				other.gameObject.GetComponent<Player>().key -= 1;
			}
		}
	}
}
