using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectablesSpawner : MonoBehaviour
{
    [Range(1,10)]
    public float delay;
    public GameObject bonus;
    public Camera mainCamera;
    private int bonusCount;
    private void Start()
    {
        bonusCount = 0;
        StartCoroutine(Spawn(delay));
    }
    public IEnumerator Spawn(float delay) //SPAWN 
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            { 
                Instantiate(bonus, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize,
                                                             mainCamera.transform.position.x + mainCamera.orthographicSize),
                                               Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize,
                                                             mainCamera.transform.position.y + mainCamera.orthographicSize)), Quaternion.identity);
            }
        }
    }
}