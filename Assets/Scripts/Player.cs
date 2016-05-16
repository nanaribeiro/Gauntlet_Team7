using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float horizontal;
	float vertical;
	Vector3 pos;
	public float moveSpeed = 2.5f;
	public float minX = -8.27f;
	public float maxX = 8.27f;
	public float minY = -3.5f;
	public float maxY = 5.41f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		vertical = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
		pos = transform.position;
		pos.x = Mathf.Clamp (pos.x + horizontal, minX, maxX);
		pos.z = Mathf.Clamp (pos.z + vertical, minY, maxY);
		transform.position = pos;
	}
}
