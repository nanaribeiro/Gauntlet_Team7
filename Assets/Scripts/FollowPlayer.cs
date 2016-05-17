using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	private Transform player;
	public float distance = 10f;
	public float height = 5f;
	public float heightDamping = 2.0f;

	// Update is called once per frame
	void LateUpdate () {
		player = GameObject.FindWithTag ("Player").GetComponent<Transform>();
		if (!player)
			return;
		float wantedHeight = player.position.y + height;
	
		float currentHeight = transform.position.y;
		
		// Damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = player.position;
		
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);
		
		// Always look at the target
		transform.LookAt(player);
	}
}
