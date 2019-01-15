using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour {

    private void Start()
    {
        this.transform.localScale = new Vector2((float)Screen.height / 1920f, (float)Screen.height / 1920f);
    }
    private void FixedUpdate()
    {
        this.transform.localScale = new Vector2((float)Screen.height / 1920f, (float)Screen.height / 1920f);

    }
}
