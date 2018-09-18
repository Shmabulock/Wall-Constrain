using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectableTrigger : MonoBehaviour
{
    public string wallsTagName;
    public string playerTagName;
    public GameObject frame;
    private collectablesSpawner collSpawner;
    GameObject leftWall;
    GameObject rightWall;
    GameObject upWall;
    GameObject downWall;
    public float bonusPower;
    Vector3 vec;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        leftWall = GameObject.Find("frame/left");
        rightWall = GameObject.Find("frame/right");
        upWall = GameObject.Find("frame/up");
        downWall = GameObject.Find("frame/down");

        collSpawner = GameObject.FindObjectOfType<collectablesSpawner>();
       // collSpawner = GameObject.FindObjectOfType<collectablesSpawner>();

        if (collision.gameObject.tag == wallsTagName)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == playerTagName)
        {
            vec.x = bonusPower*0.9f/50;
            

             leftWall.transform.position = leftWall.transform.position - vec;
             rightWall.transform.position = rightWall.transform.position + vec;
             vec.x = 0;
             vec.y = bonusPower*1.6f/50;
             upWall.transform.position = upWall.transform.position + vec;
             downWall.transform.position = downWall.transform.position - vec;

             Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        if (collSpawner != null) 
            collSpawner.GetComponent<collectablesSpawner>().setBonusCount(collSpawner.GetComponent<collectablesSpawner>().getBonusCount()-1);
    }
}

