using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public variables
	public Transform cur_target;
	public int m_health = 1;
	public int m_score = 10;
	public float m_speed = 2;
	public float m_damage = 10;
	
	//private variables
	protected Collider anObjCollider;
	protected Camera cam;//reference to camera to determine if this enemy is in the view of camera
	protected Plane[] planes;

	// Use this for initialization
	protected virtual void Start () 
	{
		cur_target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
		cam = Camera.main;
		planes = GeometryUtility.CalculateFrustumPlanes(cam);
		anObjCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		//if the enemy is within camera shot, move the enemy
		if (GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds)) {
			//run Movement script
			Movement ();
		//for other enemies, run their scripts (like ghost kamikaze, grunt melee, lobber ranged attack, etc)
		}
		else 
		{
			//do nothing
			transform.position = transform.position;
		}
	}

	//want the enemies movment to be grid like
	protected virtual void Movement()
	{
			Transform target = cur_target;
			//if player closest is not target player
			if (target != cur_target) {
				//change closest to the target player
				cur_target = target;
			}
			//if the tile the enemy wants to move in is available
			//and they are not in the middle of a move coroutine
			float step = m_speed * Time.deltaTime;
			transform.LookAt (cur_target);
			transform.position = Vector3.MoveTowards (transform.position, cur_target.position, step); 
	}

	//takes another game object that collided with it(ie. player bullet) and calculates this enemy's current health
	//returns true if some health remains, false if there is no longer any health
	public bool check_health(GameObject other)
	{
		//need projectile script completeted

		//after math is completed, check if m_health is alright
		if (m_health > 0)
			return true;
		else
			return false;
	}
}