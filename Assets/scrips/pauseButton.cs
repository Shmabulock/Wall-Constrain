using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour {

    public Animator animator;
    public string triggerName;

    public void OpenPauseMenu()
    {
        animator.SetTrigger(triggerName);
        Time.timeScale = 0;
    }
		
}

