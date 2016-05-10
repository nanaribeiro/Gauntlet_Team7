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

	public float m_spawntime;
	public int spawn_amount;

	//private variables
	private GameObject enemy_type;
	Vector3[] surTiles;
	Vector3 spawn_location;

	// Use this for initialization
	void Awake() 
	{
		//store the surrounding tiles locations in a Vector3 array
		surTiles = new Vector3[8];
		int index = 0;
		for(int x = -1; x <= 1; x++)
		{
			for(int y = -1; y <= 1; y++)
			{
				if(y == 0 && x == 0)
					continue;
				surTiles[index] = new Vector3(transform.position.x + x, 1.0f, transform.position.z + y);
				index++;

			}
		}

		//determine what enemy type to spawn
		switch (m_spawn_type) 
		{
			//set the enemy_type prefab to enemy type spawn
			case Type_spawn.Ghost:
			{
				enemy_type = _m_spawnable_enemies[0];
				break;
			}
			case Type_spawn.Grunt:
			{
				enemy_type = _m_spawnable_enemies[1];	
				break;
			}
			case Type_spawn.Lobber:
			{
				enemy_type = _m_spawnable_enemies[2];	
				break;
			}
			case Type_spawn.Sorcerer:
			{
				enemy_type = _m_spawnable_enemies[3];	
				break;
			}
			case Type_spawn.Thief:
			{
				enemy_type = _m_spawnable_enemies[4];	
				break;
			}
			case Type_spawn.Demon:
			{
				enemy_type = _m_spawnable_enemies[5];	
				break;
			}
		}
		//change skin of the spawner to match enemy's skin
		Material enemy_color = enemy_type.GetComponent<Renderer>().material;
		gameObject.GetComponent<Renderer> ().material = enemy_color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine ("Spawning_Enemy");
	}

	//coroutine that spawns enemies over certain period of time
	IEnumerator Spawning_Enemy()
	{
		for (int enemy_count = 0; enemy_count < spawn_amount; enemy_count++) 
		{
			spawn_location = new Vector3(0.0f, 0.0f, 0.0f);
			if(check_empty_nearby())
			{
				Spawn_enemy();
			}
		}
		yield return new WaitForSeconds(m_spawntime * 1.0f * Time.deltaTime);
	}

	void Spawn_enemy()
	{
		//spawn an enemy with relative strength to the spawner's health
		Debug.Log("Location: " + spawn_location.x + ", " + spawn_location.y + ", " + spawn_location.z);
		Instantiate();
	}

	//this will be the function that checks neighboring slots
	//for valid summoning of enemies
	bool check_empty_nearby()
	{
		//iterate through neighboring locations
		foreach (Vector3 elem in surTiles) 
		{
			Collider[] hitcolliders = Physics.OverlapSphere(elem, 1);
			//if space is available return true
			if(hitcolliders.Length > 0)
			{
				Debug.Log("Location empty: " + elem.x + ", " + elem.z);
				spawn_location = elem;
				return true;
			}
			Debug.Log("Location colliding: " + elem.x + ", " + elem.y);
			continue;
		}
		//return false
		return false;
	}

}
