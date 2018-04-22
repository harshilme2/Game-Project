using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float startTimer;
    private Text theText;
	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        startTimer -= Time.deltaTime;
        theText.text = "Time: " + Mathf.Round(startTimer);

        if(startTimer <= 0)
        {
            SceneManager.LoadScene("GameOverMan");
        }
	}
}
