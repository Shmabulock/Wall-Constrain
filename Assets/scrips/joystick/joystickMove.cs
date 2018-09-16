using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickMove : MonoBehaviour
{

   
    public RectTransform joystickBase;
    public float radius = 250f;
    private float x;
    private float y;
    // Update is called once per frame

    private void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            Vector3 touch;
            
            touch.x = Input.GetTouch(0).position.x + Input.GetTouch(0).deltaPosition.x;
            touch.y = Input.GetTouch(0).position.y + Input.GetTouch(0).deltaPosition.y;
            touch.z = this.GetComponent<Transform>().position.z;

            
            float MaxLength;
            MaxLength = new Vector3(radius, radius, 1).sqrMagnitude;
       
            Vector3 delta;
            delta = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, this.GetComponent<Transform>().position.z) - joystickBase.position;
            delta.Normalize();
            x = delta.x;
            y = delta.y;
            if (delta.sqrMagnitude >= MaxLength)
            { 
               
                delta.Scale(new Vector3(radius*1.35f, radius*1.35f, 1));

                this.GetComponent<Transform>().position = joystickBase.position + delta;
               
            }
          else
            {
                this.GetComponent<Transform>().position = touch;
            }
        }
    }
   public float getXAxis()
    {
        return x;
    }
    public float getYAxis()
    {
        return y;
    }
}
