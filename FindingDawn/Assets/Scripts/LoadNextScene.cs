using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextScene : MonoBehaviour {

    public string nextScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }


    public void Quit()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
}
