using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			int i = Application.loadedLevel;
			Application.LoadLevel(i+1);
		}
	}
}
