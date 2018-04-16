using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	private float levelTimer;
	public Text timerText;

	void Start(){

	}

	void Update(){

		levelTimer += Time.deltaTime;
		
		if (timerText != null){
			timerText.text = ("Time\n" + levelTimer.ToString("0"));
		}
	}

}
