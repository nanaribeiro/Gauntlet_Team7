using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Type_spawn
{
	Ghost,Grunt,Lobber,Sorcerer,Demon,Thief
}

public class Enemy_Spawner : MonoBehaviour {

	//public variables
	public Type_spawn m_spawn_type;
	public List<GameObject> _m_spawnable_enemies;
	public int m_health;

	//private variables
	private GameObject enemy_type;

	// Use this for initialization
	void awake() {
		//determine what enemy type to spawn

			//set the enemy_type prefab to enemy type spawn

			//change skin of the spawner to match enemy's skin
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawn_enemy()
	{
		//check if there is suitable space to spawn an enemy
			//spawn an enemy with relative strength to the spawner's health
	}

	//this will be the function that checks neighboring slots
	//for valid summoning of enemies
	bool check_empty_nearby()
	{
		//iterate through neighboring locations
			//if space is available return true
			return true;

		//return false
	}
}
