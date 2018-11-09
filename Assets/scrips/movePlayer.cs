﻿using UnityEngine;
using System.Collections;
public class movePlayer: MonoBehaviour
{

    public float Speed = 10;
    Rigidbody2D rb;
    Vector2 posMove;
    public Vector2 topSpeed;
    Vector2 nullSpeed;      //kinda don't need, but too lazy too check
    public GameObject joystick;   
    joystickMove joystickScript;

    Vector3 lastPos;
    Vector3 lastDiff;
    Vector3 diff;
    float torque;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nullSpeed.x = 0;//kinda don't need, but too lazy too check
        nullSpeed.y = 0;//kinda don't need, but too lazy too check
        joystickScript = joystick.GetComponent<joystickMove>();
        lastPos = this.transform.position;
        lastDiff = new Vector3(0, 0, 0);
        diff = lastDiff;
    }

    void FixedUpdate()
    {
        diff = (this.transform.position - lastPos).normalized;
        torque = lastDiff.x * diff.y - lastDiff.y * diff.x;

        rb.AddTorque(-1*torque/100, ForceMode2D.Impulse);
        
        
        posMove.x = joystickScript.getXAxis();
        posMove.y = joystickScript.getYAxis(); //kinda don't need, but too lazy too check
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


        lastDiff = (lastPos - this.transform.position).normalized;
        lastPos = this.transform.position;
        // transform.position += posMove * Time.fixedDeltaTime * Speed;


    }
}