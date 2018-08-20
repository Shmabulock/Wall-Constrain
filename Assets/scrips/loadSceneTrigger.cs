using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneTrigger : MonoBehaviour {
    public string tagName;
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagName)
            SceneManager.LoadScene(sceneName);
    }
}
