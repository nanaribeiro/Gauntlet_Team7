using UnityEngine;
using System.Collections;


public enum Type_pickup
{
	Key, Treasure, Potion, Food, FoodB
}

public class Pickup : MonoBehaviour {

	//public variables
	public Type_pickup m_type;
	public int reward_amount;
	public bool destroyable;

	//private variables

	// Use this for initialization

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//reference the player game object
			
			switch (m_type) {
				case Type_pickup.Food:
					{
						//increase player's health by reward_amount
					}
					break;
				case Type_pickup.FoodB:
					{
						//increase player's health by reward_amount
					}
					break;
				case Type_pickup.Key:
					{
						//increase player's key amount by one
						//increase player's score amount by reward amount
					}
					break;
				case Type_pickup.Potion:
					{
						//increase player's potion amount by one
						//increase player's score amount by reward amount
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
