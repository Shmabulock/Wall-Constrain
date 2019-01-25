using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
	public static void PlaySound(AudioClip clip)
    {
        if (clip.loadState == AudioDataLoadState.Unloaded || clip.loadState == AudioDataLoadState.Failed)
            clip.LoadAudioData();

        if (PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
        { 
            AudioSource.PlayClipAtPoint(clip, Camera.current.transform.position, PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY) - Random.Range(0.0f, 0.1f));
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, Camera.current.transform.position, 1.0f - Random.Range(0.0f, 0.1f));
        }
    }
    public void PlaySoundFromAudioSource()//
    {
        AudioSource source = this.GetComponent<AudioSource>();
        if(source.clip.loadState == AudioDataLoadState.Unloaded || source.clip.loadState == AudioDataLoadState.Failed)
            source.clip.LoadAudioData();

        if (PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
        {
           source.volume = PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY) - Random.Range(0.0f, 0.1f);
        }
        else
        {
            source.volume = 1.0f - Random.Range(0.0f,0.1f);
        }
        source.pitch = 1.0f + Random.Range(-0.05f, 0.05f);
        //if(!source.isPlaying)
        source.Play();
    }
}
