using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joystickMove : MonoBehaviour
{

   
    public RectTransform joystickBase;
    public bool fixedJoy;
    public float radius;
    [Range(0.0f,1)]
    public float deadZone;
    private float x;
    private float y;
    private bool isTouching = false;

    // Update is called once per frame

    private void FixedUpdate()
    {
        /*
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
          }*/
       if (Input.touchCount > 0)
        {
            Vector3 touch;
            
            touch.x = Input.GetTouch(0).position.x + Input.GetTouch(0).deltaPosition.x;
            touch.y = Input.GetTouch(0).position.y + Input.GetTouch(0).deltaPosition.y;
            touch.z = 0f;
            if (!isTouching)
            {
                setJoystickEnabled();
                joystickBase.position = touch;
                isTouching = true;
            }
            float MaxLength;
            float deltaLength;
            MaxLength = new Vector3(radius / 2, radius, 0f).sqrMagnitude; //don't get it  why the half should be here but without it,
                                                                          // joystick can be moved out of joystickBase bounds

            Vector3 delta;
            delta = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f) - joystickBase.position;
            deltaLength = delta.sqrMagnitude;
                               
            if (deltaLength >= MaxLength)
            {
                delta.Normalize();
                x = delta.x;
                y = delta.y;                                                                  
                delta.Scale(new Vector3(radius, radius, 0));
                if(!fixedJoy)
                    joystickBase.GetComponent<Transform>().position = (touch - delta);

                this.GetComponent<Transform>().position = joystickBase.position + delta;

            }
            else
            {
                float k = deltaLength / MaxLength;
                if (k < 0.5 && k > deadZone)
                    k = 0.5f;
               
           
                if (k < deadZone)
                    k = 0;

                delta.Normalize();
                x = delta.x * k ;
                y = delta.y * k ;
                this.GetComponent<Transform>().position = touch;
            }
        }
        else
        {
            this.GetComponent<Transform>().position = joystickBase.position;
            x = 0;
            y = 0;
            setJoystickDisabled();
            isTouching = false;
        }
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
    public void setJoystickDisabled()
    {
        joystickBase.gameObject.GetComponent<Image>().enabled = false;
        this.gameObject.GetComponent<Image>().enabled = false;
    }
    public void setJoystickEnabled()
    {
        joystickBase.gameObject.GetComponent<Image>().enabled = true;
        this.gameObject.GetComponent<Image>().enabled = true;
    }
}
