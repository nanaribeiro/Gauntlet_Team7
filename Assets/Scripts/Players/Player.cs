﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float horizontal;
	float vertical;
	float newFire;
	public float fireRate;
	Vector3 pos;
	public GameObject shot;
	public Transform shotSpawn;
	public float moveSpeed = 2.5f;

	public int health;
	public int score;
	public int damage;
	public int potion;
	public int key;

	protected void Movement () {
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		pos = new Vector3 (horizontal, 0f, vertical);
		if (horizontal != 0 || vertical != 0) {
			transform.rotation = Quaternion.LookRotation (pos);
		}
		transform.Translate(pos * moveSpeed * Time.deltaTime, Space.World);
	}
	protected void attack(){
		if (Input.GetButton ("Fire1") && Time.time > newFire) {
			newFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
