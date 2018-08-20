using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectableTrigger : MonoBehaviour
{
    public string tagName;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject upWall;
    public GameObject downWall;
    public float bonusPower;
    Vector3 vec;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            vec.x = bonusPower/50;
            

             leftWall.transform.position = leftWall.transform.position - vec;
             rightWall.transform.position = rightWall.transform.position + vec;
             vec.x = 0;
             vec.y = bonusPower/50;
             upWall.transform.position = upWall.transform.position - vec;
             downWall.transform.position = downWall.transform.position + vec;
            Destroy(this.gameObject);
        }
    }
}
