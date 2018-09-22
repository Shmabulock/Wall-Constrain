using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animatorSetTrigger : MonoBehaviour {

    public GameObject animator;
    public string triggerName;
    public void setTriggerTrue()
    {
        if(!animator.activeSelf)
        animator.SetActive(true);
        animator.GetComponent<Animator>().SetTrigger(triggerName);
    }
}
