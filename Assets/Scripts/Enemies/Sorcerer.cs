using UnityEngine;
using System.Collections;


//basically the same as the Enemy base class but waits to attack again
public class Sorcerer : Enemy
{
	//public
	public float m_time_to_attack = 2.0f;
	public int max_attacks;

	//private
	private bool m_made_contact;
	private int m_attacks_committed;
	private bool m_hidden;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		m_made_contact = false;
		m_hidden = false;
		m_attacks_committed = 0;
	}

	protected override void Update()
	{
		base.Update ();
		if (m_attacks_committed == max_attacks && !m_hidden) 
		{
			m_hidden = true;
			StartCoroutine ("Hide");
		}
	}

	//this is the major difference between ghost and enemy base class is how it handles collisions
	//it behaves like a kamikaze
	void OnCollisionStay(Collision other)
	{
		//if the collision was with another player
		//else if player projectile and check if dead
		if (other.gameObject.tag == "Player") 
		{
			if(!m_made_contact && !m_hidden)
				StartCoroutine ("Attacking");
			if (m_attacks_committed == max_attacks && !m_hidden) 
			{
				StartCoroutine ("Hide");
			}
		} 
	}

	//this prevents players health being drained at higher rates if grunt attacks
	IEnumerator Attacking()
	{
		m_made_contact = true;
		//get_reference to player behaviours via GetComponent<>(PLAYER_SCRIPT);

		//decrease other players health(player.change_health(-m_damage))
		Debug.Log("Hit player with " + m_damage + " damage.");

		//count the number of attacks dealt
		m_attacks_committed++;

		yield return new WaitForSeconds(m_time_to_attack);
		m_made_contact = false;
	}

	//after a certain period of attacks, the enemy disappears and becomes invulnerable and is unable to attack or deal damage to the player
	IEnumerator Hide()
	{
		m_hidden = true;
		//make the sorcerer disapear from view but remain as something that can block movement

		yield return new WaitForSeconds(m_time_to_attack*3.0f);

		//make the sorcerer reappear


		m_attacks_committed = 0;
		m_hidden = false;
	}
}
