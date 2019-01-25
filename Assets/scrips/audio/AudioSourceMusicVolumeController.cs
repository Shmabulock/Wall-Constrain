using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceMusicVolumeController : MonoBehaviour {
    AudioSource source;
    private void Awake()
    {
        source = this.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (PlayerPrefs.HasKey(KEYMANAGER.MUSICKEY))
        {
            source.volume = PlayerPrefs.GetFloat(KEYMANAGER.MUSICKEY);
        }
        else
            source.volume = 1.0f;
    }
}
