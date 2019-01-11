using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour {
    public GameObject cube;

	public void buySelectedCube()
    {
        int selectedID = cube.GetComponent<cubes>().getSelected();
        if(PlayerPrefs.GetFloat("collectablesCount") >= PlayerPrefs.GetInt("cubeID" + selectedID.ToString() + "price"))
        {
            cube.GetComponent<cubes>().unlockSelectedCube(selectedID);
            PlayerPrefs.SetString("cubeID" + selectedID.ToString() + "isLocked", "false");
            PlayerPrefs.SetFloat("collectablesCount", PlayerPrefs.GetFloat("collectablesCount") - PlayerPrefs.GetInt("cubeID" + selectedID.ToString() + "price"));
            cube.GetComponent<cubes>().checkAvailabilty();
        }
    }
}
