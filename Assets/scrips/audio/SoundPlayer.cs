using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public static void PlaySound(AudioClip clip)
    {
        if (PlayerPrefs.HasKey("soundsVolume"))
        { 
            AudioSource.PlayClipAtPoint(clip, Vector3.zero, PlayerPrefs.GetFloat("soundsVolume"));
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, Vector3.zero, 1.0f);
        }
    }
}
