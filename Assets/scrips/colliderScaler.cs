using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderScaler : MonoBehaviour
{
    public string tagName;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject upWall;
    public GameObject downWall;
    public float decreeseRate;
    public GameObject bonus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            BoxCollider2D b = GetComponent<Collider2D>() as BoxCollider2D;
            if (b != null)
            {
                b.size = new Vector2(b.size.x-decreeseRate*1.6f, b.size.y-decreeseRate*0.9f);
            }
            if (b.size.y < 0.1f)
                Destroy(b);
        } 
    }
}


