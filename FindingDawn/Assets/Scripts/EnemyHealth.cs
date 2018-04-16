using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private float health;
	public float maxHealth;

	public float contactDmg;

	public bool isHurt;
	public bool canBeHurt;
	public float damageBoostTime = 1;

	void Start () {
		health = maxHealth;
		canBeHurt = true;
	}
	
	void Update () {
		isHurt = false;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "player1"){
			print("Collision 2D Enter");
			coll.gameObject.GetComponent<PlayerController>().Hurt(contactDmg);
		} else {
			//print("Collided with:" + coll);
		}
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name == "SlashArea"){
			//print("Collided with slash");
			if (canBeHurt)
				Hurt(1);
		}
	}

	public void Hurt(float dmg){
		isHurt = true;
		StartCoroutine(DamageBoost(damageBoostTime));
		health -= dmg;
		if (health < 0) health = 0;
		if (health == 0){
			DieDestroy();
		}
	}

	void DieDestroy(){
		Destroy(this.gameObject, 0.1f);
	}

	public IEnumerator DamageBoost(float t){
		canBeHurt = false;
		yield return new WaitForSeconds(t);
		canBeHurt = true;
	}
}
