using System.Collections;
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


    void Start () {
        numberOfCubes = cubesGameObj.transform.childCount;
        Debug.Log(numberOfCubes);
        allCubes = new cube[numberOfCubes];
        for(int i = 0; i < numberOfCubes; i++)
        {
            allCubes[i].theCube = cubesGameObj.transform.GetChild(i).gameObject;
            allCubes[i].isLocked = false;
        }
        isSwitching = false;
        if (PlayerPrefs.HasKey("selected"))
            selected = PlayerPrefs.GetInt("selected");
        else
            selected = 0;
        change();
        this.GetComponent<Animator>().SetTrigger("decrease");


    }
    public void loadLeft()
    {
        if(selected > 0 && selected < numberOfCubes)
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

        if (!isSwitching)
        {
            isSwitching = true;
            this.GetComponent<Animator>().SetTrigger("decrease");
        }
    }

    public void loadRight()
    {
        
        if(selected >=0 && selected < numberOfCubes-1)
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
        if (!isSwitching)
        {
            isSwitching = true;
            this.GetComponent<Animator>().SetTrigger("decrease");
        }
    }
    public void change()
    {

        cubeInfoKeeper.GetComponent<cubeKeeper>().sprite = this.GetComponent<Image>().sprite = allCubes[selected].theCube.GetComponent<SpriteRenderer>().sprite;
        cubeInfoKeeper.GetComponent<cubeKeeper>().material = this.GetComponent<Image>().material = allCubes[selected].theCube.GetComponent<SpriteRenderer>().sharedMaterial;
        cubeInfoKeeper.GetComponent<cubeKeeper>().color = this.GetComponent<Image>().color = allCubes[selected].theCube.GetComponent<SpriteRenderer>().color;
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
   
}
