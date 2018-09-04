using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallFreezeBonusSpawner : MonoBehaviour
{
    [Range(1, 100)]
    public float delay;
    public GameObject bonus;
    Camera mainCamera;
    bool wallFreezeBonusCollected;

    public GameObject frame;
    GameObject leftWall;   
    GameObject rightWall;   
    GameObject upWall;
    GameObject downWall;

    float horizontalWallSpeed;
    float verticalWallSpeed;
    float freezeTime = 5f;



    private void Start()
    {
        leftWall = GameObject.Find("frame/left");
        rightWall = GameObject.Find("frame/right");      
        upWall = GameObject.Find("frame/up");
        downWall = GameObject.Find("frame/down");
        mainCamera = Camera.main;
        wallFreezeBonusCollected = false;

        StartCoroutine(Spawn(delay));
        StartCoroutine(unfreezeWalls());
    }
    public IEnumerator unfreezeWalls()
    {
        while(true)
        {
            if(wallFreezeBonusCollected)
            {
                yield return new WaitForSeconds(freezeTime);
                leftWall.GetComponent<wallMove>().Speed = horizontalWallSpeed;
                rightWall.GetComponent<wallMove>().Speed = horizontalWallSpeed;
                upWall.GetComponent<wallMove>().Speed = verticalWallSpeed;
                downWall.GetComponent<wallMove>().Speed = verticalWallSpeed;
                wallFreezeBonusCollected = false;
            }
        }
    }
    public IEnumerator Spawn(float delay) //SPAWN 
    {
        while (true)
        {
            if (!wallFreezeBonusCollected)
            {
                delay += Random.Range(-20, 20);
                yield return new WaitForSeconds(delay);
                addBonus(bonus);
            }
        }

    }
    void addBonus(GameObject bonus)
    {
        Instantiate(bonus, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize / 3,
                                                     mainCamera.transform.position.x + mainCamera.orthographicSize / 3),
                                       Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize / 3,
                                                     mainCamera.transform.position.y + mainCamera.orthographicSize / 3)), Quaternion.identity);
    }
    public void setBonusCollected(bool a)
    {
        wallFreezeBonusCollected = a;
    }
    public void setHorizontalWallSpeed(float speed)
    {
        horizontalWallSpeed = speed;
    }
    public void setVerticalWallSpeed(float speed)
    {
        horizontalWallSpeed = speed;
    }
    public void setFreezeTime(float time)
    {
        freezeTime = time;
    }
}