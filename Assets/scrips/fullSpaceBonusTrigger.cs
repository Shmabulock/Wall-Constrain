using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fullSpaceBonusTrigger : MonoBehaviour
{
    public string wallsTagName;
    public string playerTagName;
    public GameObject frame;
    fullSpaceBonusSpawner spawner;
    GameObject leftWall;
    GameObject rightWall;
    GameObject upWall;
    GameObject downWall;
    private bool playerCollected = false;
    Vector3 vec;


    private void OnTriggerEnter2D(Collider2D collision)
    {


        spawner = GameObject.FindObjectOfType<fullSpaceBonusSpawner>();

        if (collision.gameObject.tag == wallsTagName)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == playerTagName)
        {
            // set bool collected true;
            playerCollected = true;
            Destroy(this.gameObject);
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

