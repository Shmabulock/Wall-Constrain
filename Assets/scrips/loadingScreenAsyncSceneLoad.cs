using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingScreenAsyncSceneLoad : MonoBehaviour {

    public   string sceneName;
	// Use this for initialization
	void Start () {
        StartCoroutine(loadScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator loadScene()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);

        while(!loading.isDone)
        {
            yield return null;
        }
    }
}
