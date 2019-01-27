using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class phoneBackButton : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == SCENE_NAMES.MainMenu)
            {
                Application.Quit();
            }
            else
            {
                if(sceneName == SCENE_NAMES.CubeSelection || sceneName == SCENE_NAMES.Options || sceneName == SCENE_NAMES.Tutorial)
                {
                    GameObject.Find("backButton").GetComponent<animatorSetTrigger>().setTriggerTrue();
                }
                else
                {
                    if(sceneName == SCENE_NAMES.Gameplay)
                    {
                        GameObject.Find("pauseButton").GetComponent<pauseButton>().OpenPauseMenu();
                    }
                }
            }

        }
    }

}
