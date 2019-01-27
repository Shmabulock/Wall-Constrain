using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicForGameplay : MonoBehaviour
{

    [SerializeField] AudioClip musicPart1;
    [SerializeField] AudioClip musicPart2;
    public AudioSource source;

    public int partPlaying;
    bool once = true;
    // Use this for initialization
    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
        source.clip = musicPart1;
        partPlaying = 1;
        if(PlayerPrefs.HasKey(KEYMANAGER.MUSICKEY))
        {
            source.volume = PlayerPrefs.GetFloat(KEYMANAGER.MUSICKEY);
        }
        else
        {
            source.volume = 1.0f;
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale > 0)
        {
            if (partPlaying == 1)
            {
                if (!source.isPlaying)
                {
                    source.Play();
                    partPlaying = 2;
                }
            }
            if (partPlaying == 2)
            {
                if (!source.isPlaying)
                {
                    if (once)
                    {
                        once = !once;
                        source.clip = musicPart2;
                        source.loop = true;
                        source.Play();
                    }

                }
            }
        }
    }
}