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
    private float collectedThisGame;
    [SerializeField] Transform root;
    AudioSource source;

   // public enum  type {circle = 0,  fullSpaceBunus = 1}

  //  public type type1;


    private void Start()
    {
        bonusCount = 0;
        StartCoroutine(Spawn(delay));
        source = this.GetComponent<AudioSource>();
        source.clip.LoadAudioData();

    }
    private void FixedUpdate()
    {
       // Debug.Log(bonusCount);
        if(bonusCount < 1 && (Random.Range(0,1)%2)==0 )
        {
            addBonus();
        }
        if (bonusCount < 2 && (Random.Range(0, 9) % 10) == 0)
        {
            addBonus();
        }
    }
    public IEnumerator Spawn(float delay) //SPAWN 
    {
        while (true)
        {
            if(bonusCount < 2)
            {
                addBonus();
                continue;
            }
            yield return new WaitForSeconds(delay);
            {
                addBonus();
            }
        }
    }
    public void addBonus()
    {
        bonusCount++;
        Instantiate(bonus, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize,
                                                     mainCamera.transform.position.x + mainCamera.orthographicSize),
                                       Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize,
                                                     mainCamera.transform.position.y + mainCamera.orthographicSize)), Quaternion.identity, root);
    }
    public void addBonusAtPos(Vector3 pos)
    {
        bonusCount++;
        Instantiate(bonus, new Vector2(Random.Range(pos.x - mainCamera.orthographicSize/4,
                                                     pos.x + mainCamera.orthographicSize/4),
                                       Random.Range(pos.y - mainCamera.orthographicSize/4,
                                                     pos.y + mainCamera.orthographicSize/4)), Quaternion.identity, root);
    }
    public void setBonusCount(int Count)
    {
        bonusCount = Count;
    }
    public int getBonusCount()
    {
        return bonusCount;
    }
    public void increeseCollectedThisGameBy(float a)
    {
        collectedThisGame += a;
    }
    public float getCollectedThisGame()
    {
        return collectedThisGame;
    }
    public void PlayCollectableSound()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
        {
            source.volume = PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY) - Random.Range(0.0f, 0.1f);
        }
        else
        {
            source.volume = 1.0f - Random.Range(0.0f, 0.1f);
        }
        source.pitch = 1.0f + Random.Range(-0.05f, 0.05f);
        //if(!source.isPlaying)
        source.Play();
    }
}