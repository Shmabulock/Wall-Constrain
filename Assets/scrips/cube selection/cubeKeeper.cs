using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cubeKeeper : MonoBehaviour {

    public Sprite sprite;
    public Material material;
    public Color color;
    private bool wasInGameplay = false;
    private bool wasInGameover = false;
    private GameObject player;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(((SceneManager.GetActiveScene().name == "gameplay" && !wasInGameplay) || (SceneManager.GetActiveScene().name == "gameplay") && wasInGameover))
        {
            player = GameObject.FindWithTag("Player");
                        
            player.GetComponent<SpriteRenderer>().sprite = sprite;
            player.GetComponent<SpriteRenderer>().material = material;
            player.GetComponent<SpriteRenderer>().color = color;
            wasInGameplay = true;
            wasInGameover = false;
        }
        if (SceneManager.GetActiveScene().name == "cubeSelection" && wasInGameplay)
            Destroy(this.gameObject);
        if (SceneManager.GetActiveScene().name == "gameOver")
            wasInGameover = true;
        if (SceneManager.GetActiveScene().name == "loadingScreenToGameplay")
            wasInGameplay = false;
    }
}

