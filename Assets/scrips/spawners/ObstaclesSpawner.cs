using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject obstackles;
    private Camera mainCamera;
    private int obstaclesCount;
    private Transform[] allObstacles;
    [SerializeField] Transform root;
    [SerializeField] collectablesSpawner colSpawner;

    private void Start()
    {


        obstaclesCount = 0;
        allObstacles = obstackles.GetComponentsInChildren<Transform>();
        Debug.Log(allObstacles.Length);
        mainCamera = Camera.main;

    }
    private void FixedUpdate()
    {
        // Debug.Log(allObstacles[1].transform);
        if (obstaclesCount < 1 && (Random.Range(0, 1) % 2) == 0)
        {
            GameObject tmp = allObstacles[Random.Range(1, allObstacles.Length)].gameObject;
            //tmp.AddComponent<figureMove>();
            int tmpDir = Random.Range(0, 4);
            switch (tmpDir)
            {
                case 0:
                    {
                        tmp.GetComponent<figureMove>().SetNapr(figureMove.Napr.left);
                        tmp.GetComponent<figureMove>().destroyDelay = 60;
                        break;
                    }
                case 1:
                    {
                        tmp.GetComponent<figureMove>().SetNapr(figureMove.Napr.right);
                        tmp.GetComponent<figureMove>().destroyDelay = 60;
                        break;
                    }
                case 2:
                    {
                        tmp.GetComponent<figureMove>().SetNapr(figureMove.Napr.up);
                        tmp.GetComponent<figureMove>().destroyDelay = 30;
                        break;
                    }
                case 3:
                    {
                        tmp.GetComponent<figureMove>().SetNapr(figureMove.Napr.down);
                        tmp.GetComponent<figureMove>().destroyDelay = 30;
                        break;
                    }

            }
            tmp.GetComponent<figureMove>().rotationSpeed = Random.Range(-1.0f, 1.0f);
            tmp.GetComponent<figureMove>().Speed = Random.Range(0.5f, 1.0f);
            tmp.GetComponent<figureMove>().destroyDelay += Random.Range(5.0f,10.0f);
            addBonus(tmp);
            Debug.Log(Time.fixedDeltaTime);

        }

    }
    void addBonus(GameObject obstacle)
    {
        obstaclesCount++;
       // Debug.Log(obstacle.GetComponent<figureMove>().what);
        switch (obstacle.GetComponent<figureMove>().GetNapr())
        {
            case (figureMove.Napr.left):
                {
                    Instantiate(obstacle, new Vector2(mainCamera.transform.position.x + 3.0f * mainCamera.orthographicSize,
                                                      Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize,
                                                                   mainCamera.transform.position.y + mainCamera.orthographicSize)), Quaternion.identity, root);
                    break;
                }
            case (figureMove.Napr.right):
                {
                    Instantiate(obstacle, new Vector2(mainCamera.transform.position.x - 3.0f * mainCamera.orthographicSize,
                                                     Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize,
                                                                  mainCamera.transform.position.y + mainCamera.orthographicSize)), Quaternion.identity, root);
                    break;
                }
            case (figureMove.Napr.up):
                {
                    Instantiate(obstacle, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize,
                                                                   mainCamera.transform.position.x + mainCamera.orthographicSize),
                                                     mainCamera.transform.position.y - 3.0f * mainCamera.orthographicSize), Quaternion.identity, root);
                    break;
                }
            case (figureMove.Napr.down):
                {
                    Instantiate(obstacle, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize,
                                                                   mainCamera.transform.position.x + mainCamera.orthographicSize),
                                                     mainCamera.transform.position.y + 3.0f * mainCamera.orthographicSize), Quaternion.identity, root);
                    break;
                }
        }

    }
    public void setObstaclesCount(int Count)
    {
        obstaclesCount = Count;
    }
    public int getObstaclesCount()
    {
        return obstaclesCount;
    }
    public void spawnNCollectables(Vector3 pos, int N)
    {
        for(int i = 0; i < N; i++)
        {
            colSpawner.addBonusAtPos(pos);
        }
    }

}