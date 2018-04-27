using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour {

    public string nextScene;
    public GameObject Level;
    public string Text;


    //public void Start()
    //{
    //    Level.GetComponent<Text>().text = nextScene;
    //    print("TriggeredLevelTransition");
    //    Text = Level.GetComponent<Text>().text.ToString();
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Level.GetComponent<Text>().text = nextScene;
            Text = Level.GetComponent<Text>().text.ToString();
            print("Lvlis: " + Text);
            SceneManager.LoadScene(nextScene);
        }
    }


}
