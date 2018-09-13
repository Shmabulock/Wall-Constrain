using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateTimer : MonoBehaviour {

    public Text timerText;
    public void setTimerActive()
    {
        timerText.gameObject.SetActive(true);
        
    }
    public void setTimeScale(float a)
    {
        Time.timeScale = a;
    }
}
