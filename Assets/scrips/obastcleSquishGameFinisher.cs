using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obastcleSquishGameFinisher : MonoBehaviour {

    [SerializeField] Frame frame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacles" || collision.tag == "Walls")
        {
            frame.EndGame();
        }
    }
}
