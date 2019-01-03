﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;//kinda lazy to check but don't need;

public class cubes : MonoBehaviour {

    public GameObject cubesGameObj;
    public GameObject cubeInfoKeeper;

    bool isSwitching;
    public struct cube
    {
        public GameObject theCube;
        public bool isLocked;
    };

    cube[] allCubes;
    int selected;
    int numberOfCubes;
    public Text CubeNumber;

    bool isSwiping = false;
    float delta = 0;
    Vector2 touchSwipeStartPos;
    public float swipelength;

    public GameObject playButton;
    public GameObject BuyButton;


    void Start () {
        numberOfCubes = cubesGameObj.transform.childCount;
        Debug.Log(numberOfCubes);
        allCubes = new cube[numberOfCubes];


        for(int i = 0; i < numberOfCubes; i++)
        {
            if (!PlayerPrefs.HasKey("cubeID" + i.ToString() + "isLocked"))
                PlayerPrefs.SetString("cubeID" + i.ToString() + "isLocked", "true");
            if (PlayerPrefs.HasKey("cubeID" + i.ToString() + "isLocked"))
            {
                if(PlayerPrefs.GetString("cubeID" + i.ToString() + "isLocked") == "true")
                {
                    if (!PlayerPrefs.HasKey("cubeID" + i.ToString() + "price"))
                        PlayerPrefs.SetInt("cubeID" + i.ToString() + "price", (i) * 500);
                }
            }
                allCubes[i].theCube = cubesGameObj.transform.GetChild(i).gameObject;
            allCubes[i].isLocked = PlayerPrefs.GetString("cubeID" + i.ToString() + "isLocked") == "true" ? true : false;
        }
        PlayerPrefs.SetString("cubeID" + "0" + "isLocked", "false");
        allCubes[0].isLocked = PlayerPrefs.GetString("cubeID" + "0" + "isLocked") == "true" ? true : false;


        isSwitching = false;
        if (PlayerPrefs.HasKey("selected"))
            selected = PlayerPrefs.GetInt("selected");
        else
            selected = 0;
        change();
        this.GetComponent<Animator>().SetTrigger("decrease"); // this is needed for the first cube rotation, without  it doesnt change cube in first button press


    }

    public void FixedUpdate()
    {
        if (!isSwitching)
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
                            loadRight();

                        }
                        else
                        {
                            loadLeft();
                        }
                    }

                }
            }
            else
                isSwiping = false;
        }

       


       /* if (!isSwitching)
        {
            if (Input.touchCount >= 1)
            {
                delta = Input.GetTouch(0).deltaPosition.x;
                if (delta != 0)
                {
                    delta = Mathf.Sign(delta);
                    if (delta < 0)
                    {
                        loadLeft();

                    }
                    else
                    {
                        loadRight();
                    }
                }
            }
        }*/
    }

    public void loadLeft()
    {
        if (!isSwitching)
        {
            isSwitching = true;
            if (selected > 0 && selected < numberOfCubes)
            {
                selected--;
            }
            else
                if(selected == 0)
                {
                    selected = numberOfCubes - 1;
                }
            Debug.Log("left ");
            Debug.Log(selected);

       
            this.GetComponent<Animator>().SetTrigger("decrease");
        }
    }
    public void loadRight()
    {
        if (!isSwitching)
        {
            isSwitching = true;
            if (selected >=0 && selected < numberOfCubes-1)
            {
                selected++;
            }
            else
                if(selected == numberOfCubes-1)
                {
                    selected = 0;
                }
            Debug.Log("right ");
            Debug.Log(selected);
        
            this.GetComponent<Animator>().SetTrigger("decrease");
        }
    }
    public void change()
    {

        cubeInfoKeeper.GetComponent<cubeKeeper>().sprite = this.GetComponent<Image>().sprite = allCubes[selected].theCube.GetComponent<SpriteRenderer>().sprite;
        cubeInfoKeeper.GetComponent<cubeKeeper>().material = this.GetComponent<Image>().material = allCubes[selected].theCube.GetComponent<SpriteRenderer>().sharedMaterial;
        cubeInfoKeeper.GetComponent<cubeKeeper>().color = this.GetComponent<Image>().color = allCubes[selected].theCube.GetComponent<SpriteRenderer>().color;
        checkAvailabilty();
        this.GetComponent<Animator>().SetTrigger("increase");
        CubeNumber.text = selected+1 + "/" + numberOfCubes;
        
        PlayerPrefs.SetInt("selected", selected);

    }
    public void resetTriggers()
    {
        isSwitching = false;

        this.GetComponent<Animator>().ResetTrigger("decrease");
        this.GetComponent<Animator>().ResetTrigger("increase");
    }
   
    public void checkAvailabilty()
    {
        if (allCubes[selected].isLocked)
        {
            Color locked = Color.gray;
            locked.r = 0.3f;
            locked.g = 0.3f;
            locked.b = 0.3f;
            locked.a = 1f;
            this.GetComponent<Image>().color = locked;
            BuyButton.SetActive(true);
            playButton.SetActive(false);
            BuyButton.GetComponent<Transform>().GetChild(1).GetComponent<Text>().text = "X" + PlayerPrefs.GetInt("cubeID" + selected + "price").ToString();
        }
        else
        {
            BuyButton.SetActive(false);
            playButton.SetActive(true);
        }
    }
    public void buySelectedCube()
    {

    }

   
}
