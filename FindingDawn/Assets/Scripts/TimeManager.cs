using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float startTimer;
    private bool add;
    public GameObject TimeBoost;
    private Text theText;
	// Use this for initialization
	void Start () {
        theText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        startTimer -= Time.deltaTime;
        Timer();
        
        if (add)
        {
            startTimer += 10;
            add = false;
        }
            
        if(startTimer <= 0)
        {
            SceneManager.LoadScene("GameOverMan");
        }
	}
    public void Timer()
    {
        theText.text = "Time: " + Mathf.Round(startTimer);

    }
    public void AddTime()
    {
        add = true;
        //startTimer += ti;
        //Destroy(ti);
    }

    public IEnumerator Flash(Color col)
    {
        var texts = GetComponentsInChildren<Text>();

        foreach (Text element in texts)
            element.color = col;

        yield return new WaitForSeconds(0.2f);

        foreach (Text element in texts)
            element.color = Color.white;

    }
}
