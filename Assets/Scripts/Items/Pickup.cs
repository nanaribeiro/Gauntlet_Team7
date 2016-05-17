using UnityEngine;
using System.Collections;


//script by Colby

public enum Type_pickup
{
	Key, Treasure, Potion, Food, FoodB
}

public class Pickup : MonoBehaviour {

	//public variables
	public Type_pickup m_type;

	//reward amount is the amount of something a player will get for picking up the item(could either be health or score)
	public int reward_amount;
	public bool destroyable;

	//private variables

	// Use this for initialization

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//reference the player game object
			
			switch (m_type) {
				case Type_pickup.Food:
					{
						//increase player's health by reward_amount
						other.gameObject.GetComponent<Player>().health += reward_amount;
					}
					break;
				case Type_pickup.FoodB:
					{
						//increase player's health by reward_amount
						other.gameObject.GetComponent<Player>().health += reward_amount;
					}
					break;
				case Type_pickup.Key:
					{
						//increase player's key amount by one
						other.gameObject.GetComponent<Player>().key += 1;
						//increase player's score amount by reward amount
						other.gameObject.GetComponent<Player>().score += reward_amount;
					}
					break;
				case Type_pickup.Potion:
					{
						//increase player's potion amount by one
						other.gameObject.GetComponent<Player>().potion += 1;
						//increase player's score amount by reward amount
						other.gameObject.GetComponent<Player>().score += reward_amount;
					}
					break;
				case Type_pickup.Treasure:
					{
						//increase player's score amount by reward amount
						other.gameObject.GetComponent<Player>().score += reward_amount;
					}
					break;
				default:
					break;
			}
			//destroy the object to simulate collection
			Destroy (gameObject);
		}
	}
}
