using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullSpaceBonusSpawner : MonoBehaviour
{
    [Range(1, 100)]
    public float delay;
    public GameObject bonus;
    Camera mainCamera;
    bool fullSpaceBonusCollected;

    public GameObject frame;
    GameObject leftWall;
    Vector3 leftWallOldPos;
    Vector3 leftWallPos;

    GameObject rightWall;
    Vector3 rightWallOldPos;
    Vector3 rightWallPos;

    GameObject upWall;
    Vector3 upWallOldPos;
    Vector3 upWallPos;

    GameObject downWall;
    Vector3 downWallOldPos;
    Vector3 downWallPos;

    float percent = 0f;
    Vector3 vec;

    private void Start()
    {
        leftWall = GameObject.Find("frame/left");
        leftWallPos = leftWall.transform.position;

        rightWall = GameObject.Find("frame/right");
        rightWallPos = rightWall.transform.position;

        upWall = GameObject.Find("frame/up");
        upWallPos = upWall.transform.position;

        downWall = GameObject.Find("frame/down");
        downWallPos = downWall.transform.position;

        mainCamera = Camera.main;
        fullSpaceBonusCollected = false;

        StartCoroutine(Spawn(delay));
    }
    private void FixedUpdate()
    {
        if (!fullSpaceBonusCollected)
        {
            leftWallOldPos = leftWall.transform.position;
            rightWallOldPos = rightWall.transform.position;
            upWallOldPos = upWall.transform.position;
            downWallOldPos = downWall.transform.position;

        }
        if (fullSpaceBonusCollected)
        {
            percent += 0.01f;
            rightWall.transform.position = Vector3.Lerp(rightWallOldPos, rightWallPos, percent);
            leftWall.transform.position = Vector3.Lerp(leftWallOldPos, leftWallPos, percent);
            upWall.transform.position = Vector3.Lerp(upWallOldPos, upWallPos, percent);
            downWall.transform.position = Vector3.Lerp(downWallOldPos, downWallPos, percent);
        }
        if (percent > 0.9f)
        {
            percent = 0f;
            fullSpaceBonusCollected = false;
           
        }
    }
    public IEnumerator Spawn(float delay) //SPAWN 
    {
        while (true)
        {
            delay += Random.Range(-20, 20);
            yield return new WaitForSeconds(delay);
            addBonus(bonus);
        }

    }
    void addBonus(GameObject bonus)
    {
        Instantiate(bonus, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize/3,
                                                     mainCamera.transform.position.x + mainCamera.orthographicSize/3),
                                       Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize/3,
                                                     mainCamera.transform.position.y + mainCamera.orthographicSize/3)), Quaternion.identity);
    }
    public void setBonusCollected(bool a)
    {
        fullSpaceBonusCollected = a;
    }
}