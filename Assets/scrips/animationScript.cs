using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationScript : MonoBehaviour {

    public GameObject animator;
    public string triggerName;
    public string sceneName;
    public void startAnimation()
    {
        if(!animator.activeSelf)
        animator.SetActive(true);
        animator.GetComponent<Animator>().SetTrigger(triggerName);
    }

    public void loadScene()
    {

        SceneManager.LoadScene(sceneName);
    }
}
