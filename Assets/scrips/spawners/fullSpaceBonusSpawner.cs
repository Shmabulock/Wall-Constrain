using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullSpaceBonusSpawner : MonoBehaviour
{
    [Range(1, 100)]
    public float delay;
    public GameObject bonus;
    Camera mainCamera;
    [SerializeField] Frame frame;
    [SerializeField] Transform root;
     AudioSource source;
    [SerializeField] AudioClip FullSpaceClip;



    private void Start()
    {
        FullSpaceClip.LoadAudioData();
        source = this.GetComponent<AudioSource>();
        mainCamera = Camera.main;

        StartCoroutine(Spawn(delay));
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
                                                     mainCamera.transform.position.y + mainCamera.orthographicSize/3)), Quaternion.identity, root);
    }
    public void setBonusCollected(bool a)
    {
        frame.IsFullSpaceBonusCollected = a;
    }
    public void PlayFullSpaceStart()
    {
        if (!source.isPlaying)
        {
            if(PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
            {
                source.volume = PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY);
            }
            else
            {
                source.volume = 1.0f;
            }
            source.clip = FullSpaceClip;
            source.Play();
        }
    }
}