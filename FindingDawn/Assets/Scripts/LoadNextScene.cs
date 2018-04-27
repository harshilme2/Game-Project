using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour {

    public string nextScene;
    public GameObject Level;
    public string Text;

    public void Start()
    {
        //Level.GetComponent<Text>().text = nextScene;
        if (Text != "1")
            nextScene = Level.GetComponent<Text>().text.ToString();
        else
            Level.GetComponent<Text>().text = "Level1";

        print("Next Level: " + nextScene);
    }
    public void ChangeScene()
    {
        //Text = Level.GetComponent<Text>().text.ToString();
        //var n = GetComponent<UILevelName>().GetName();
        
        //if (Text == "1")
        //{
        //    print("inside");
        //    Level.GetComponent<Text>().text = "Level1";
        //}
        //else
        //{
        //    print("outside");
        //}
        SceneManager.LoadScene(nextScene);
    }


    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
