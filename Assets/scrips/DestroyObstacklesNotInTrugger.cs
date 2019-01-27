using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacklesNotInTrugger : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TAGS.Obastcles)
            Destroy(collision.gameObject);
    }
}
