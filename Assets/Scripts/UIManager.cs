using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Text player;

	public void setPlayer(Text play)
	{
		if (play.text == "Elf") {
			player.text = "Elf";
			PlayerPrefs.SetString ("player", "Elf");
		} else if (play.text == "Valkirye") {
			player.text = "Valkirye";
			PlayerPrefs.SetString ("player", "Valkirye");
		} else if (play.text == "Warrior") {
			player.text = "Warrior";
			PlayerPrefs.SetString ("player", "Warrior");
		} else if (play.text == "Wizard") {
			player.text = "Wizard";
			PlayerPrefs.SetString("player", "Wizard");
		}
	}
	// Use this for initialization
	void Start () {
		player.text = PlayerPrefs.GetString ("player");
	}
	public void gameStart(){
		Application.LoadLevel ("enemy_tester");
	}
}
