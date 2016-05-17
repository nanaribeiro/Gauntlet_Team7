using UnityEngine;
using System.Collections;

public class Elf : Player {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Call function for basic movement
		Movement ();
		attack ();
	}
}
