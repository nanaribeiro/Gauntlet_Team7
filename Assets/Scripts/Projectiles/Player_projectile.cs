using UnityEngine;
using System.Collections;

public class Player_projectile : Projectile 
{
	public GameObject m_owner;

	protected override void Awake()
	{
		gameObject.tag = "Player_Projectile";
		base.Awake();
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Enemy temp = other.gameObject.GetComponent<Enemy> ();
			if (!temp.check_health (gameObject)) 
			{
				//increase player's score that launched the projectile(player.Change_Score(+m_score))
				//destroy other object
			}
		}

		if (other.gameObject.tag == "Pickup") 
		{
			//get pickup reference(other.gameObject.getComponent<PickUp>();)

			//check pickup reference type to determine if it is breakable by attacks
				//destroy it
				//display message regarding "Player" + m_owner.classtype + " broke the food" via gamemanager controller
		}

		//if this collides with anything just destroy it, 
		//shouldnt go through enemies since players wouldn't be able to see it coming at them
		Destroy (gameObject);
	}
}
