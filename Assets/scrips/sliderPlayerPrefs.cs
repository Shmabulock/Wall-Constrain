using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderPlayerPrefs : MonoBehaviour {

    public enum Key {music, sounds }
    public Key forWhat;

    string key;

    private void Start()
    {
        key = forWhat == 0 ? KEYMANAGER.MUSICKEY : KEYMANAGER.SOUNDSKEY;

        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetFloat(key, 1f);
        }
        else
        {
            this.GetComponent<Slider>().value = PlayerPrefs.GetFloat(key);
        }
    }
    public void writeSliderValueToPlayerPrefsByKey()
    {
        PlayerPrefs.SetFloat(key, this.GetComponent<Slider>().value);
    }
}
