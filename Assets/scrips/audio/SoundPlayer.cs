using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public static void PlaySound(AudioClip clip)
    {
        if (PlayerPrefs.HasKey(KEYMANAGER.SOUNDSKEY))
        { 
            AudioSource.PlayClipAtPoint(clip, Vector3.zero, PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY));
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, Vector3.zero, 1.0f);
        }
    }
}
