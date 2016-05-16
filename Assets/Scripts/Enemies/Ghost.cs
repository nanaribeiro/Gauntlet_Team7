using UnityEngine;
using System.Collections;


//basically the same as the Enemy base class, except for how it handles collisions
public class Ghost : Enemy
{
	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		//add anything here?
	}

	//this is the major difference between ghost and enemy base class is how it handles collisions
	//it behaves like a kamikaze
	void OnCollisionStay(Collision other)
	{
		//if the collision was with another player
		//else if player projectile and check if dead
		if (other.gameObject.tag == "Player") {
			//get_reference to player behaviours via GetComponent<>(PLAYER_SCRIPT);

			//decrease other players health(player.change_health(-m_damage))

			//destroy this object
			DestroyObject(gameObject);
		} 
	}
}
