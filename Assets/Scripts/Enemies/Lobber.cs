using UnityEngine;
using System.Collections;


//script by Colby

//basically the same as the Enemy base class but waits to attack again
public class Lobber : Enemy
{
	//public
	public float m_time_to_attack = 3.0f;
	public GameObject projectile;

	//private
	private bool m_shot;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		m_shot = false;
	}

	protected override void Update()
	{
		base.Update ();
		if (!m_shot && GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
			StartCoroutine("Throwing");
	}

	//
	protected override void Movement()
	{
		//want lobber to keep its distance, so check to see how far it is and if it is too close do not move
		if (Vector3.Distance(transform.position, cur_target.position) <= 5) {
			transform.position = transform.position;
		} 
		else 
		{
			base.Movement ();
		}
	}

	//this prevents lobber from spamming shots every few seconds
	IEnumerator Throwing()
	{
		m_shot = true;

		//instantiate a projectile that is launched into air in direction of the current target player and have it fall towards player (lob a projectile)
		Instantiate(projectile, transform.position, Quaternion.identity);

		//since this enemy projectile should behave differently, then need to access and set its target location
		Enemy_projectile tmp = projectile.GetComponent<Enemy_projectile>();
		tmp.Set_target(cur_target.position); 

		yield return new WaitForSeconds(m_time_to_attack);
		m_shot = false;
	}
}
