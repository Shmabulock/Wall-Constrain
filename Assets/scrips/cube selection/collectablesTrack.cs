using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collectablesTrack : MonoBehaviour {

   // public GameObject collectablesSpawner;
    public string tagName;
    bool written = false;

    [SerializeField]
    collectablesSpawner spawner;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("collectablesCount"))
            PlayerPrefs.SetFloat("collectablesCount", 0);
    }
    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "cubeSelection")
        {
            this.GetComponent<Text>().text = "x" + PlayerPrefs.GetFloat("collectablesCount").ToString("0");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            if (!PlayerPrefs.HasKey("collectablesCount"))
                PlayerPrefs.SetFloat("collectablesCount", 0);
            else
            {
                if (!written)
                {
                    //PlayerPrefs.SetFloat("collectablesCount", PlayerPrefs.GetFloat("collectablesCount") + collectablesSpawner.GetComponent<collectablesSpawner>().getCollectedThisGame());
                    PlayerPrefs.SetFloat("collectablesCount", PlayerPrefs.GetFloat("collectablesCount") + spawner.getCollectedThisGame());

                    written = true;
                }
            }
        }
    }
}
