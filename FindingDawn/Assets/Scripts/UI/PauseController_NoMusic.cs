using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseController_NoMusic : MonoBehaviour {

    // uncomment these if you want music and have appropriate files
    //public AudioMixerSnapshot paused;
    //public AudioMixerSnapshot unpaused;

    private Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // toggle paused or unpaused
        //ChangeSound(); // uncomment this if you want music again
    }

    /* uncomment this is you want music again
    void ChangeSound()
    {
        if(Time.timeScale == 0)
        {
            // Paused
            // Play paused music
            paused.TransitionTo(0.01f);
        }
        else
        {
            // Not paused
            // Play regular music
            unpaused.TransitionTo(0.01f);
        }
    }
    */

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
