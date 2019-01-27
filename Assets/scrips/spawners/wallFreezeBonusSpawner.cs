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

    [SerializeField] Frame frame;
    [SerializeField] Transform root;

    [SerializeField] AudioClip WallFreezeStartClip;
    [SerializeField] AudioClip WallFreezeEndClip;
    AudioSource source;
  /*  GameObject leftWall;   
    GameObject rightWall;   
    GameObject upWall;
    GameObject downWall;*/

   /* float horizontalWallSpeed;
    float verticalWallSpeed;*/
   // float freezeTime = 5f;



    private void Start()
    {
        source = this.GetComponent<AudioSource>();
       /* leftWall = GameObject.Find("frame/left");
        rightWall = GameObject.Find("frame/right");      
        upWall = GameObject.Find("frame/up");
        downWall = GameObject.Find("frame/down");*/
        mainCamera = Camera.main;
        // wallFreezeBonusCollected = false;
        WallFreezeEndClip.LoadAudioData();
        WallFreezeStartClip.LoadAudioData();
        StartCoroutine(Spawn(delay));
       // StartCoroutine(unfreezeWalls(freezeTime));

    }
   /* public IEnumerator unfreezeWalls(float time)
    {
      //  Debug.Log("log");
        while(true)
        {
            yield return time;
           // Debug.Log("while");
           if(wallFreezeBonusCollected)
            {
                //Debug.Log("if");
                yield return new WaitForSeconds(time);
              //  Debug.Log("yield");
                leftWall.GetComponent<wallMove>().Speed = horizontalWallSpeed;
                rightWall.GetComponent<wallMove>().Speed = horizontalWallSpeed;
                upWall.GetComponent<wallMove>().Speed = verticalWallSpeed ;
                downWall.GetComponent<wallMove>().Speed = verticalWallSpeed;
                wallFreezeBonusCollected = false;
            }
        }
    }*/
    public IEnumerator Spawn(float delay) //SPAWN 
    {
        while (true)
        {
          //  delay += Random.Range(-20, 20);
            yield return new WaitForSeconds(delay + Random.Range(-20, 20));
            if (!wallFreezeBonusCollected)
            {
                addBonus(bonus);
            }
        }

    }
    void addBonus(GameObject bonus)
    {
        Instantiate(bonus, new Vector2(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize / 3,
                                                     mainCamera.transform.position.x + mainCamera.orthographicSize / 3),
                                       Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize / 3,
                                                     mainCamera.transform.position.y + mainCamera.orthographicSize / 3)), Quaternion.identity, root);
        
    }
    public void setBonusCollected(bool a)
    {
        frame.IsWallFreezeBonusCollected = a;
        wallFreezeBonusCollected = a;
    }

    public void PlayWallFreezeStart()
    {

        if(!source.isPlaying)
        {
            if (PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
            {
                source.volume = PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY);
            }
            else
            {
                source.volume = 1.0f;
            }
            source.clip = WallFreezeStartClip;
            source.Play();
            Debug.Log("clipStart");
        }
    }
    public void PlayWallFreezeEnd()
    {
        if (PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
        {
            source.volume = PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY);
        }
        else
        {
            source.volume = 1.0f;
        }
        source.clip = WallFreezeEndClip;
        source.Play();
        Debug.Log("clipStop");
    }
   /* public void setHorizontalWallSpeed(float speed)
    {
        horizontalWallSpeed = speed;
    }
    public void setVerticalWallSpeed(float speed)
    {
       verticalWallSpeed = speed;
    }
    public void setFreezeTime(float time)
    {
        freezeTime = time;
    }*/
}