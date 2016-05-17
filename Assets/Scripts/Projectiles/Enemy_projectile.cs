using UnityEngine;
using System.Collections;

public class Enemy_projectile : Projectile 
{
	//public variables
	public bool lobb;
	public float m_heightofArc = 4.0f;

	//private
	private Vector3 start_pos;
	private Vector3 end_pos;
	private float lerp_pos;
	private Vector3 this_transform;

	private bool m_has_target;

	protected override void Awake()
	{
		gameObject.tag = "Enemy_Projectile";
		start_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		this_transform = transform.position;
		lerp_pos = 0.0f;
		m_has_target = false;
		base.Awake();
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//deal damage to player via health altercation script
			other.gameObject.GetComponent<Player>().health -= m_damage;
		}

		//destroy object if it collides with anything other than an enemy
		if (other.gameObject.tag == "Enemy")
			return;
		else
			Destroy (gameObject);
	}

	protected override void Movement()
	{
		//if the projectile is a lobbable object, then calculate the trajectory
		if (lobb) 
		{
			if(m_has_target)
			{
				lerp_pos = Mathf.Clamp(lerp_pos + Time.deltaTime * m_speed, 0.0f, 1.0f);
				this_transform = Vector3.Lerp(start_pos, end_pos, lerp_pos);
				this_transform.y =  m_heightofArc * Mathf.Sin(lerp_pos * Mathf.PI);
			}
		} 
		else
			base.Movement ();
	}

	public void Set_target(Vector3 location)
	{
		end_pos = new Vector3 (location.x, location.y - 2, location.z);
	}
}
