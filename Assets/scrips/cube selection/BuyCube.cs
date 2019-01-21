using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour {
    public GameObject cube;

	public void buySelectedCube()
    {
        int selectedID = cube.GetComponent<cubes>().getSelected();
        if(PlayerPrefs.GetFloat(KEYMANAGER.COLLECTABLES_COUNT) >= PlayerPrefs.GetInt(KEYMANAGER.CUBES.CUBE_ID + selectedID.ToString() + KEYMANAGER.CUBES.PRICE))
        {
            cube.GetComponent<cubes>().unlockSelectedCube(selectedID);
            PlayerPrefs.SetString(KEYMANAGER.CUBES.CUBE_ID + selectedID.ToString() + KEYMANAGER.CUBES.IS_LOCKED, KEYMANAGER.CUBES.FALSE);
            PlayerPrefs.SetFloat(KEYMANAGER.COLLECTABLES_COUNT, PlayerPrefs.GetFloat(KEYMANAGER.COLLECTABLES_COUNT) - PlayerPrefs.GetInt(KEYMANAGER.CUBES.CUBE_ID + selectedID.ToString() + KEYMANAGER.CUBES.PRICE));
            cube.GetComponent<cubes>().checkAvailabilty();
        }
    }
}
