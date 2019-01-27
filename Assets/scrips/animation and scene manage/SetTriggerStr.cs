using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerStr : MonoBehaviour {

    public static void SetTrigger(Animator anim, string triggerName, bool state)
    {
        if(state)
        {
            anim.SetTrigger(triggerName);
        }
        else
        {
            anim.ResetTrigger(triggerName);
        }
    }
}
