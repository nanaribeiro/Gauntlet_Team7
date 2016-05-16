using UnityEngine;
using System.Collections;


//basically the same as the Enemy base class but waits to attack again
public class Demon : Enemy
{
	//public
	public float m_time_to_attack = 2.0f;
	public GameObject projectile;

	//private
	private bool m_shot;
	private bool m_can_move;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		m_shot = false;
		m_can_move = true;
	}

	protected override void Update()
	{
		base.Update ();
		if (!m_shot && GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
			StartCoroutine("Shooting");
	}
		
	protected override void Movement()
	{
		if (m_can_move) 
		{
			base.Movement ();
		}

	}

	//this prevents lobber from spamming shots every few seconds
	IEnumerator Shooting()
	{
		m_shot = true;
		m_can_move = false;

		//instantiate a projectile that is launched in direction of the current target player
		Instantiate(projectile, transform.position, Quaternion.identity);

		yield return new WaitForSeconds(m_time_to_attack/2.0f);
		m_can_move = true;
		yield return new WaitForSeconds(m_time_to_attack);
		m_shot = false;
	}
}
