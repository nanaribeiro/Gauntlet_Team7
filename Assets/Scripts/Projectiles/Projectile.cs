using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	//public variables
	public float m_speed = 10.0f;
	public int m_damage = 1;

	//private variables
	protected Transform m_position;

	protected virtual void Awake()
	{
		m_position = transform;
	}

	// Update is called once per frame
	void Update () 
	{
		Movement ();
	}

	void set_material(Material mat)
	{
		Renderer rend_tmp = GetComponent<Renderer>();
		rend_tmp.material = mat;
	}

	protected virtual void Movement()
	{
		m_position.Translate (Vector3.forward * m_speed * Time.deltaTime);
	}
}
