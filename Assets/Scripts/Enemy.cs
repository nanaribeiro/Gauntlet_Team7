using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public variables
	public Transform cur_target;
	public int m_health = 1;
	public int m_score = 10;
	public float m_speed = 2;
	
	//private variables

	// Use this for initialization
	void Start () 
	{
		cur_target = GameObject.Find ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//run Movement script
		Movement ();
		//for other enemies, run their scripts (like ghost kamikaze, grunt melee, lobber ranged attack, etc)
	}

	//want the enemies movment to be grid like
	void Movement()
	{
		//if the enemy is within camera shot, move the enemy
		if (GetComponent<Renderer>().isVisible) {
			//iterate through all party members and determine who is closer

			Transform target = cur_target;
			//if player closest is not target player
			if (target != cur_target) {
				//change closest to the target player
				cur_target = target;
			}
			//if the tile the enemy wants to move in is available
			//and they are not in the middle of a move coroutine
			float step = m_speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, cur_target.position, step);
		} 
		else 
		{
			//do nothing
			transform.position = transform.position;
		}
	}
}
