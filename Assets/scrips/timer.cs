using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour {
    public Text TimerText;
    private float myTimer;
	// Use this for initialization
	void Start () {
        myTimer = 0f;
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName == "gameplay")
        {
            myTimer += Time.deltaTime;
            TimerText = GameObject.Find("timerText").GetComponent<Text>();
            TimerText.text = myTimer.ToString("F");
        }
        if (Application.loadedLevelName == "gameOver")
        {
            TimerText = GameObject.Find("score").GetComponent<Text>();
            TimerText.text = myTimer.ToString("F");
        }

    }
}
