using UnityEngine;
using System.Collections;
public class movePlayer: MonoBehaviour
{

    public float Speed = 10;
    Rigidbody2D rb;
    Vector2 posMove;
    public Vector2 topSpeed;
    Vector2 nullSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nullSpeed.x = 0;
        nullSpeed.y = 0;

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        posMove.x = x;
        posMove.y = y;
        //posMove.z = 0;
        if (Mathf.Abs(rb.velocity.x) < Mathf.Abs(topSpeed.x) )
        {
            posMove.y = 0;
            rb.AddForceAtPosition(posMove, rb.position, ForceMode2D.Impulse);
        }

        if (Mathf.Abs(rb.velocity.y) < Mathf.Abs(topSpeed.y))
        {
            posMove.y = y;
            posMove.x = 0;
            rb.AddForceAtPosition(posMove, rb.position, ForceMode2D.Impulse);
        }
       


        // transform.position += posMove * Time.fixedDeltaTime * Speed;


    }
}