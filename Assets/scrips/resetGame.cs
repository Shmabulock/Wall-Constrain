using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGame : MonoBehaviour {

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
