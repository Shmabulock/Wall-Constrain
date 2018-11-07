using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour {

	// Use this for initialization
	public void resetTrigger(string str)
    {
        this.GetComponent<Animator>().ResetTrigger(str);
    }
}
