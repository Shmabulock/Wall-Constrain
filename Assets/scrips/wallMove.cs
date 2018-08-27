using UnityEngine;
using System.Collections;
public class wallMove : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float Speed = 1;
    public enum Napr  {left,right,up,down};
    public Napr what;
    float x;
    float y;
    float multiplier;
    int counter;
    Vector3 moveVec;
    void Start()
    {
        counter = 1;
        multiplier = 1.0f;
     switch(what)
        {
            case Napr.left:
                {
                    x = -1;
                    y = 0;
                    break;
                }
            case Napr.right:
                {
                    x = 1;
                    y = 0;
                    break;
                }
            case Napr.up:
                {
                    x = 0;
                    y = 1;
                    break;
                }
            case Napr.down:
                {
                    x = 0;
                    y = -1;
                    break;
                }


        }
        moveVec.x = x * Speed * Time.fixedDeltaTime;
        moveVec.y = y * Speed * Time.fixedDeltaTime;
        moveVec.z = 0;

    }

    void FixedUpdate()
    {
        moveVec.x = x * Speed * multiplier * Time.fixedDeltaTime;
        moveVec.y = y * Speed * multiplier * Time.fixedDeltaTime;
        transform.position = transform.position + moveVec;
        counter++;
        if(counter%1000 == 0)
        {
            counter = 1;
            multiplier += 0.05f;
        }
    }

    
}