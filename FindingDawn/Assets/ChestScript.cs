using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	public Sprite closedSprite;
	public Sprite openSprite;

	public bool isOpen = false;
	public List<GameObject> loot = new List<GameObject>();

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.transform.name.Contains("player")){
			if (!isOpen) OpenChest();
		}
	}

	void OpenChest(){
		GetComponent<SpriteRenderer>().sprite = openSprite;
		foreach (GameObject loot in loot){
			Instantiate(loot, transform.position, Quaternion.identity);
		}
		isOpen = true;
	}
}
