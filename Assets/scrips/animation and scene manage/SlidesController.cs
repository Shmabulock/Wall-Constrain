using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidesController : MonoBehaviour {

    Vector3 OUT_SCENE_POS_RIGHT = new Vector3(1105.0f, -305.0f, 10.0f);
    Vector3 OUT_SCENE_POS_LEFT = new Vector3(-1105.0f, -305.0f, 10.0f);
    [SerializeField] Button buttonLeft;
    [SerializeField] Button buttonRight;
    [SerializeField] Text slideNumber;

    bool isSwiping = false;
    float delta = 0;
    Vector2 touchSwipeStartPos;
    float swipelength = Screen.width/3.0f;

    public static Animator [] allSlides;

    int NumberOfSlides;
    public static int selected = 0;

    private void Awake()
    {
        NumberOfSlides = this.transform.childCount;
        allSlides = new Animator[NumberOfSlides];

        for(int i = 0; i <  NumberOfSlides; i++)
        {
            allSlides[i] = this.transform.GetChild(i).gameObject.GetComponent<Animator>();
            allSlides[i].gameObject.SetActive(false);
        }
        allSlides[selected].gameObject.SetActive(true);

        slideNumber.text = (selected + 1).ToString() + "/" + NumberOfSlides;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount >= 1)
        {
            if (!isSwiping)
            {
                isSwiping = true;
                delta = 0;
                touchSwipeStartPos = Input.GetTouch(0).position;
            }
            else
            {
                delta = Input.GetTouch(0).position.x - touchSwipeStartPos.x;
                if (Mathf.Abs(delta) > swipelength)
                {
                    delta = Mathf.Sign(delta);
                    if (delta < 0)
                    {
                        LoadRight();
                        isSwiping = false;
                    }
                    else
                    {
                        LoadLeft();
                        isSwiping = false;

                    }
                }

            }
        }
        else
            isSwiping = false;
    }

    public void LoadLeft()
    {
        if (selected > 0)
        {
            if(!buttonRight.enabled)
            {
                buttonRight.enabled = true;
            }
            GoFromSceneToRight(allSlides[selected]);
            selected--;

            allSlides[selected].gameObject.transform.position = OUT_SCENE_POS_LEFT;
            allSlides[selected].gameObject.SetActive(true);

            GoOnSceneFromleft(allSlides[selected]);

            slideNumber.text = (selected + 1).ToString() + "/" + NumberOfSlides;
        }
        else
            buttonLeft.enabled = false;
    }
    public void LoadRight()
    {
        if(selected < NumberOfSlides -1)
        {
            if(!buttonLeft.enabled)
            {
                buttonLeft.enabled = true;
            }
            buttonLeft.enabled = true;
            GoFromSceneToLeft(allSlides[selected]);
            selected++;

            allSlides[selected].gameObject.transform.position = OUT_SCENE_POS_RIGHT;
            allSlides[selected].gameObject.SetActive(true);

            GoOnSceneFromRight(allSlides[selected]);

            slideNumber.text = (selected + 1).ToString() + "/" + NumberOfSlides;
        }
        else
        {
            buttonRight.enabled = false;
        }
    }
    public void GoFromSceneToLeft(Animator anim)
    {
        SetTriggerStr.SetTrigger(anim, "GoFromSceneToLeftTrigger", true);
    }
    public void GoOnSceneFromRight(Animator anim)
    {
        SetTriggerStr.SetTrigger(anim, "GoOnSceneFromRightTrigger", true);
    }


    public void GoFromSceneToRight(Animator anim)
    {
        SetTriggerStr.SetTrigger(anim, "GoFromSceneToRightTrigger", true);
    }
    public void GoOnSceneFromleft(Animator anim)
    {
        SetTriggerStr.SetTrigger(anim, "GoOnSceneFromLeftTrigger", true);
    }

}
