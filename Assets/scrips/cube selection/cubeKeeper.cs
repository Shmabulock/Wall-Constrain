using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cubeKeeper : MonoBehaviour {

    public Sprite sprite;
    public Material material;
    public Color color;
    
    private GameObject player;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().name == "gameplay")
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
                Debug.Log("blya");
            
            player.GetComponent<SpriteRenderer>().sprite = sprite;
            player.GetComponent<SpriteRenderer>().material = material;
            player.GetComponent<SpriteRenderer>().color = color;
            Destroy(this.gameObject);
        }
    }
}

