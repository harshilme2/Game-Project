using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHUD : MonoBehaviour {

	public GameObject player;
	public Text uiHP;
	public Text uiBombs;
    public GameObject heart1;

	void CreateHud(){

	}

	public void UpdateHud(){

		var ply = player.GetComponent<PlayerManager>();

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

		
		uiBombs.text= "Score : " + ply.bombs;

		if (ply.playerNo == 1){

			
			uiBombs.alignment = TextAnchor.UpperLeft;
			uiHP.alignment = TextAnchor.UpperLeft;

		} else if (ply.playerNo == 2){

			
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
