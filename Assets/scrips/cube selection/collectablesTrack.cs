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
        if (!PlayerPrefs.HasKey(KEYMANAGER.COLLECTABLES_COUNT))
            PlayerPrefs.SetFloat(KEYMANAGER.COLLECTABLES_COUNT, 0);
    }
    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == SCENE_NAMES.CubeSelection)
        {
            this.GetComponent<Text>().text = "x" + PlayerPrefs.GetFloat(KEYMANAGER.COLLECTABLES_COUNT).ToString("0");
        }

    }// i know this is is not good :)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            if (!PlayerPrefs.HasKey(KEYMANAGER.COLLECTABLES_COUNT))
                PlayerPrefs.SetFloat(KEYMANAGER.COLLECTABLES_COUNT, 0);
            else
            {
                if (!written)
                {
                    //PlayerPrefs.SetFloat("collectablesCount", PlayerPrefs.GetFloat("collectablesCount") + collectablesSpawner.GetComponent<collectablesSpawner>().getCollectedThisGame());
                    PlayerPrefs.SetFloat(KEYMANAGER.COLLECTABLES_COUNT, PlayerPrefs.GetFloat(KEYMANAGER.COLLECTABLES_COUNT) + spawner.getCollectedThisGame());

                    written = true;
                }
            }
        }
    }
}
