using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emoteNeutralTrigger : MonoBehaviour
{
    public GameObject emotes;
    Transform[] theEmotes;

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

        if (collision.gameObject.tag == TAGS.Walls)
        {
            emoteHappy.GetComponent<SpriteRenderer>().enabled = false;
            emoteNeutral.GetComponent<SpriteRenderer>().enabled = true;
            emoteSad.GetComponent<SpriteRenderer>().enabled = false;
            emoteCrying.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("neutral");
        theEmotes = emotes.GetComponentsInChildren<Transform>();
        emoteHappy = theEmotes[4].gameObject;
        emoteNeutral = theEmotes[3].gameObject;
        emoteSad = theEmotes[2].gameObject;
        emoteCrying = theEmotes[1].gameObject;

        if (collision.gameObject.tag == TAGS.Walls)
        {
            emoteHappy.GetComponent<SpriteRenderer>().enabled = true;
            emoteNeutral.GetComponent<SpriteRenderer>().enabled = false;
            emoteSad.GetComponent<SpriteRenderer>().enabled = false;
            emoteCrying.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}