using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public variables
	public Transform target;
	public int m_health;
	public int m_score;
	
	//private variables

	// Use this for initialization
	void Start () 
	{

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
		//if the tile the enemy wants to move in is available
		//and they are not in the middle of a move coroutine

			//if player closest is not target player
				//change closest to the target player
			//run the move couroutine

			//do nothing
	}
}
