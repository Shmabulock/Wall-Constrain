using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class collectableTrigger : MonoBehaviour
{
    public string wallsTagName;
    public string playerTagName;
    Frame frame;
    private collectablesSpawner collSpawner;
   /* GameObject leftWall;
    GameObject rightWall;
    GameObject upWall;
    GameObject downWall;*/
  /*  float bonusPower = 10;*/
    float superModScaler = 1;
   // Vector3 vec;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        frame = GameObject.Find("FrameSetter").GetComponent<Frame>();
        /*leftWall = GameObject.Find("frame/left");
        rightWall = GameObject.Find("frame/right");
        upWall = GameObject.Find("frame/up");
        downWall = GameObject.Find("frame/down");*/

        collSpawner = GameObject.FindObjectOfType<collectablesSpawner>();
       // collSpawner = GameObject.FindObjectOfType<collectablesSpawner>();

        if (collision.gameObject.tag == wallsTagName)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == playerTagName)
        {
            if (collision.gameObject.GetComponent<movePlayer>().isInSupermode())
            {
                superModScaler = 1.2f;
            }
            else
            {
                superModScaler = 1f;
            }

            frame.ThrowWallsAway(superModScaler);

            collSpawner.GetComponent<collectablesSpawner>().increeseCollectedThisGameBy(superModScaler);
            
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        if (collSpawner != null) 
            collSpawner.GetComponent<collectablesSpawner>().setBonusCount(collSpawner.GetComponent<collectablesSpawner>().getBonusCount()-1);

    }
}

