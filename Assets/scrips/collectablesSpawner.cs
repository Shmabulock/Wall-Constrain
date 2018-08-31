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
    private void FixedUpdate()
    {
       // Debug.Log(bonusCount);
        if(bonusCount < 1 && (Random.Range(0,1)%2)==0 )
        {
            addBonus(bonus);
        }
        if (bonusCount < 2 && (Random.Range(0, 9) % 10) == 0)
        {
            addBonus(bonus);
        }
    }
    public IEnumerator Spawn(float delay) //SPAWN 
    {
        while (true)
        {
            if(bonusCount < 2)
            {
                addBonus(bonus);
                continue;
            }
            yield return new WaitForSeconds(delay);
            {
                addBonus(bonus);
            }
        }
    }
    void addBonus(GameObject bonus)
    {
        bonusCount++;
        Instantiate(bonus, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize,
                                                     mainCamera.transform.position.x + mainCamera.orthographicSize),
                                       Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize,
                                                     mainCamera.transform.position.y + mainCamera.orthographicSize)), Quaternion.identity);
    }
    public void setBonusCount(int Count)
    {
        bonusCount = Count;
    }
    public int getBonusCount()
    {
        return bonusCount;
    }
}