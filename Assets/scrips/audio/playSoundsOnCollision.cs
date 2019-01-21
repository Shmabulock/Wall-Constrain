using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playSoundsOnCollision : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip clip;
    
    string collisionTag = "collectable";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("played1");

        if (collision.gameObject.tag == collisionTag)
        {
            Debug.Log("played");
            audioSource.PlayOneShot(clip, PlayerPrefs.GetFloat(KEYMANAGER.SOUNDSKEY));
            
        }
    }


}
