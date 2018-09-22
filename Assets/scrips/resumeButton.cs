using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeButton : MonoBehaviour {

    public Animator animator;
    public string triggerName;

    public void closePauseMenu()
    {
        animator.SetTrigger(triggerName);
        Time.timeScale = 0;
    }
}
