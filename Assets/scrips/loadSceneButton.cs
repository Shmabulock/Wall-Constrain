using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadSceneButton : MonoBehaviour {
    public string sceneName;

    // Use this for initialization
    public void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
    //  SceneManager.LoadScene(sceneName);
}
