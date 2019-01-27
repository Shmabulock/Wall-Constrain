using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fullSpaceBonusTrigger : MonoBehaviour
{

    public GameObject frame;
    fullSpaceBonusSpawner spawner;
    GameObject leftWall;
    GameObject rightWall;
    GameObject upWall;
    GameObject downWall;
    private bool playerCollected = false;




    private void OnTriggerEnter2D(Collider2D collision)
    {


        spawner = GameObject.FindObjectOfType<fullSpaceBonusSpawner>();

        if (collision.gameObject.tag == TAGS.Walls)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == TAGS.Player)
        {
            // set bool collected true;
            playerCollected = true;
            Destroy(this.gameObject);
            spawner.PlayFullSpaceStart();
        }
    }
    private void OnDestroy()
    {

        if (spawner != null && playerCollected)
        {
            spawner.GetComponent<fullSpaceBonusSpawner>().setBonusCollected(true);
            playerCollected = false;
        }
    }
}

