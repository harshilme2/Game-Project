using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float TheScore;
    private Text theText;
    // Use this for initialization
    void Start()
    {
        theText = GetComponent<Text>();
    }

    // Update is called once per frame
   
    public void Scorer()
    {
        theText.text = "Time: " + Mathf.Round(TheScore);

    }
    public void AddScore()
    {
        
        TheScore += 100;
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
