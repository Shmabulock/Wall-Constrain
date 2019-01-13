using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetGame : MonoBehaviour {

    bool isReseting = false;
    public void ResetGame()
    {
        if (isReseting)
        {
            PlayerPrefs.DeleteAll();
            this.transform.GetChild(0).GetComponent<Text>().text = "Done";
        }
        else
            StartCoroutine(prepeareForReset());

    }
    private void Start()
    {
        
            this.transform.GetChild(0).GetComponent<Text>().text = "Reset game";
    }
    IEnumerator prepeareForReset()
    {
        Text textOnButton = this.transform.GetChild(0).GetComponent<Text>();
        textOnButton.text = "wait";
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            textOnButton.text += ".";   
        }
        yield return new WaitForSeconds(1);
        textOnButton.text = "Sure?";
        isReseting = true;
        yield break;
    }
}
