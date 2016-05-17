using UnityEngine;
using System.Collections;


//script by Colby

//basically the same as the Enemy base class but waits to attack again
public class Thief : Enemy
{
	//public
	public float m_time_to_attack = 2.0f;

	//private
	private bool m_made_contact;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		m_made_contact = false;
	}

	//this is the major difference between ghost and enemy base class is how it handles collisions
	//it behaves like a kamikaze
	void OnCollisionStay(Collision other)
	{
		//if the collision was with another player
		//else if player projectile and check if dead
		if (other.gameObject.tag == "Player") 
		{
			player_target = other.gameObject.GetComponent<Player>();
			if(!m_made_contact)
				StartCoroutine ("Robbing");
		} 
	}

	//this prevents players health being drained at higher rates if grunt attacks
	IEnumerator Robbing()
	{
		m_made_contact = true;
		//decrease other players health(player.change_health(-m_damage))
		player_target.health -= m_damage;

		//decrease other players score and increase this enemy's score for the damage it does
		player_target.score -= m_damage;
		m_score += m_damage;

		yield return new WaitForSeconds(m_time_to_attack);
		m_made_contact = false;
	}
}
