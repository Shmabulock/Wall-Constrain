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
        if((SceneManager.GetActiveScene().name == SCENE_NAMES.Gameplay && !wasInGameplay) || 
            (SceneManager.GetActiveScene().name == SCENE_NAMES.Gameplay && wasInGameover))
        {
            player = GameObject.FindWithTag(TAGS.Player);
                        
            player.GetComponent<SpriteRenderer>().sprite = sprite;
            player.GetComponent<SpriteRenderer>().material = material;
            player.GetComponent<SpriteRenderer>().color = color;
            wasInGameplay = true;
            wasInGameover = false;
        }
        if (SceneManager.GetActiveScene().name == SCENE_NAMES.CubeSelection && wasInGameplay)
            Destroy(this.gameObject);
        if (SceneManager.GetActiveScene().name == SCENE_NAMES.GameOver)
            wasInGameover = true;
        if (SceneManager.GetActiveScene().name == SCENE_NAMES.LoadingScreenToGameplay)
            wasInGameplay = false;
    }
}

