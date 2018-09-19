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
               touch.z = 0f;

              float MaxLength;
              float deltaLength;
              MaxLength = new Vector3(radius/2, radius, 0f).sqrMagnitude; //don't get it  why the half should be here but without it,
                                                                          // joystick can be moved out of joystickBase bounds

              Vector3 delta;
              delta = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f) - joystickBase.position;
              deltaLength = delta.sqrMagnitude;
              delta.Normalize();
              x = delta.x;
              y = delta.y;
              if (deltaLength >= MaxLength)
              {
               
                  delta.Scale(new Vector3(radius, radius, 0));

                  this.GetComponent<Transform>().position = joystickBase.position + delta;

              }
            else
              {
                  this.GetComponent<Transform>().position = touch;
              }
          }
          else
          {
              this.GetComponent<Transform>().position = joystickBase.position;
              x = 0;
              y = 0;
          }
       /* if (Input.touchCount > 0)
        {
            Vector3 touch;

            touch.x = Input.GetTouch(0).position.x + Input.GetTouch(0).deltaPosition.x;
            touch.y = Input.GetTouch(0).position.y + Input.GetTouch(0).deltaPosition.y;
            touch.z = 0f;

            float MaxLength;
            float deltaLength;
            MaxLength = new Vector3(radius / 2, radius, 0f).sqrMagnitude; //don't get it  why the half should be here but without it,
                                                                          // joystick can be moved out of joystickBase bounds

            Vector3 delta;
            delta = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f) - joystickBase.position;
            deltaLength = delta.sqrMagnitude;
            delta.Normalize();
            x = delta.x;
            y = delta.y;                    
            if (deltaLength >= MaxLength)
            {
                joystickBase.GetComponent<Transform>().position = (touch - delta);                      // used with no image like on all of the screen
                delta.Scale(new Vector3(radius, radius, 0));

                this.GetComponent<Transform>().position = joystickBase.position + delta;

            }
            else
            {
                this.GetComponent<Transform>().position = touch;
            }
        }
        else
        {
            this.GetComponent<Transform>().position = joystickBase.position;
            x = 0;
            y = 0;
        }*/
        /*if (Input.touchCount > 0)
        {
            Vector3 touch;

            touch.x = Input.GetTouch(0).deltaPosition.x;
            touch.y = Input.GetTouch(0).deltaPosition.y;
            touch.z = 0f;

            float MaxLength;                    // ny takoe
            float deltaLength;



            touch.Normalize();
            x = touch.x;
            y = touch.y;
        }
        else
        {
            x = 0;
            y = 0;
        }*/

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
