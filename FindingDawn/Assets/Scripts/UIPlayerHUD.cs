using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHUD : MonoBehaviour {

	public GameObject player;
	public Text uiHP;
<<<<<<< HEAD
=======
	public Text uiKeys;
>>>>>>> 3861963047fcefb1dac5b4d60ed818fd64541e86
	public Text uiBombs;
    public GameObject heart1;

	void CreateHud(){

	}

	public void UpdateHud(){

<<<<<<< HEAD
		var ply = player.GetComponent<PlayerManager>();
=======
		var ply = player.GetComponent<PlayerController>();
>>>>>>> 3861963047fcefb1dac5b4d60ed818fd64541e86

		uiHP.text =  "HP:\n";

		var hp = player.GetComponent<PlayerHealth>();
		string stringHP = "";
		for(var i = 0; i < hp.maxHealth; i++){
			if (i+1 <= hp.health){
				stringHP += "*";
			} else {
                heart1.SetActive(false);
				stringHP += "-";
			}
		}
		uiHP.text += stringHP;

<<<<<<< HEAD
		
=======
		uiKeys.text = "Keys  x " + ply.keys;
>>>>>>> 3861963047fcefb1dac5b4d60ed818fd64541e86
		uiBombs.text= "Bombs x " + ply.bombs;

		if (ply.playerNo == 1){

<<<<<<< HEAD
			
=======
			uiKeys.alignment = TextAnchor.UpperLeft;
>>>>>>> 3861963047fcefb1dac5b4d60ed818fd64541e86
			uiBombs.alignment = TextAnchor.UpperLeft;
			uiHP.alignment = TextAnchor.UpperLeft;

		} else if (ply.playerNo == 2){

<<<<<<< HEAD
			
=======
			uiKeys.alignment = TextAnchor.UpperRight;
>>>>>>> 3861963047fcefb1dac5b4d60ed818fd64541e86
			uiBombs.alignment = TextAnchor.UpperRight;
			uiHP.alignment = TextAnchor.UpperRight;

		}
	}

	// public void Flash(Color col){

	// }

	public IEnumerator Flash(Color col){
		var texts = GetComponentsInChildren<Text>();

		foreach (Text element in texts)
			element.color = col;
		
		yield return new WaitForSeconds(0.2f);

		foreach (Text element in texts)
			element.color = Color.white;

	}

}
