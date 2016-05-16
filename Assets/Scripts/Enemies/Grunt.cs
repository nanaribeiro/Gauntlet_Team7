using UnityEngine;
using System.Collections;


//basically the same as the Enemy base class but waits to attack again
public class Grunt : Enemy
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
			if(!m_made_contact)
				StartCoroutine ("Attacking");
		} 
	}

	//this prevents players health being drained at higher rates if grunt attacks
	IEnumerator Attacking()
	{
		m_made_contact = true;
		//get_reference to player behaviours via GetComponent<>(PLAYER_SCRIPT);

		//decrease other players health(player.change_health(-m_damage))
		Debug.Log("Hit player with " + m_damage + " damage.");
		yield return new WaitForSeconds(m_time_to_attack);
		m_made_contact = false;
	}
}
