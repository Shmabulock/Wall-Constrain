using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emoteCryingTrigger : MonoBehaviour
{
    public GameObject emotes;
    Transform[] theEmotes;
    public string wallTagName;
    GameObject emoteHappy;
    GameObject emoteNeutral;
    GameObject emoteSad;
    GameObject emoteCrying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theEmotes = emotes.GetComponentsInChildren<Transform>();
        emoteHappy = theEmotes[4].gameObject;
        emoteNeutral = theEmotes[3].gameObject;
        emoteSad = theEmotes[2].gameObject;
        emoteCrying = theEmotes[1].gameObject;

        if (collision.gameObject.tag == wallTagName)
        { 
            emoteHappy.GetComponent<SpriteRenderer>().enabled = false;
        emoteNeutral.GetComponent<SpriteRenderer>().enabled = false;
        emoteSad.GetComponent<SpriteRenderer>().enabled = false;
        emoteCrying.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("sad");
        theEmotes = emotes.GetComponentsInChildren<Transform>();
        emoteHappy = theEmotes[4].gameObject;
        emoteNeutral = theEmotes[3].gameObject;
        emoteSad = theEmotes[2].gameObject;
        emoteCrying = theEmotes[1].gameObject;

        if (collision.gameObject.tag == wallTagName)
        {
            emoteHappy.GetComponent<SpriteRenderer>().enabled = false;
            emoteNeutral.GetComponent<SpriteRenderer>().enabled = false;
            emoteSad.GetComponent<SpriteRenderer>().enabled = true;
            emoteCrying.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}