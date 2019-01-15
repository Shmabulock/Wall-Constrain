using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wallFreezeBonusTrigger : MonoBehaviour
{
    public string wallsTagName;
    public string playerTagName;
  //  public GameObject frame;
   // public float freezeTime;
    wallFreezeBonusSpawner wallFreezeSpawner;
   /* GameObject leftWall;
    GameObject rightWall;
    GameObject upWall;
    GameObject downWall;*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*leftWall = GameObject.Find("frame/left");
        rightWall = GameObject.Find("frame/right");
        upWall = GameObject.Find("frame/up");
        downWall = GameObject.Find("frame/down");
        */
        wallFreezeSpawner = GameObject.FindObjectOfType<wallFreezeBonusSpawner>();

        if (collision.gameObject.tag == wallsTagName)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == playerTagName)
        {
            /*wallFreezeSpawner.GetComponent<wallFreezeBonusSpawner>().setHorizontalWallSpeed(leftWall.GetComponent<wallMove>().Speed);
            wallFreezeSpawner.GetComponent<wallFreezeBonusSpawner>().setVerticalWallSpeed(upWall.GetComponent<wallMove>().Speed);
            wallFreezeSpawner.GetComponent<wallFreezeBonusSpawner>().setFreezeTime(freezeTime + Random.Range(-1f,1f));
            leftWall.GetComponent<wallMove>().Speed = 0;
            rightWall.GetComponent<wallMove>().Speed = 0;
            upWall.GetComponent<wallMove>().Speed = 0;
            downWall.GetComponent<wallMove>().Speed = 0;*/

            wallFreezeSpawner.setBonusCollected(true);

            Destroy(this.gameObject);
        }
    }
}

