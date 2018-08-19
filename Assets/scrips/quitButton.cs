using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quitButton : MonoBehaviour
{

    // Use this for initialization
    public void OnMouseDown()
    {
         Application.Quit();
    }
    //  SceneManager.LoadScene(sceneName);
}

