using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] player;
	private string selectedPlayer;

	// Use this for initialization
	void Awake () {
		selectedPlayer = PlayerPrefs.GetString ("player");
		if (selectedPlayer == "Wizard") {
			Instantiate (player [0]);
		} else if (selectedPlayer == "Warrior") {
			Instantiate (player [1]);
		} else if (selectedPlayer == "Valkirye") {
			Instantiate (player [2]);
		} else if (selectedPlayer == "Elf") {
			Instantiate(player[3]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
