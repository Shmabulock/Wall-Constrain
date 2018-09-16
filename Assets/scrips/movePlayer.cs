using UnityEngine;
using System.Collections;
public class movePlayer: MonoBehaviour
{

    public float Speed = 10;
    Rigidbody2D rb;
    Vector2 posMove;
    public Vector2 topSpeed;
    Vector2 nullSpeed;
    public GameObject joystick;
   
    joystickMove joystickScript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nullSpeed.x = 0;
        nullSpeed.y = 0;
        joystickScript = joystick.GetComponent<joystickMove>();
    }

    void FixedUpdate()
    {
      
        posMove.x = joystickScript.getXAxis();
        posMove.y = joystickScript.getYAxis();
        //posMove.z = 0;
        if (Mathf.Abs(rb.velocity.x) < Mathf.Abs(topSpeed.x) )
        {
            posMove.y = 0;
            rb.AddForceAtPosition(posMove, rb.position, ForceMode2D.Impulse);
        }

        if (Mathf.Abs(rb.velocity.y) < Mathf.Abs(topSpeed.y))
        {
            posMove.y = joystickScript.getYAxis();
            posMove.x = 0;
            rb.AddForceAtPosition(posMove, rb.position, ForceMode2D.Impulse);
        }
       


        // transform.position += posMove * Time.fixedDeltaTime * Speed;


    }
}