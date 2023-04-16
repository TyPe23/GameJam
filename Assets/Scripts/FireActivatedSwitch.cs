using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivatedSwitch : MonoBehaviour
{
    public bool active = false;

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("fire"))
        {
            active = true;
        }
    }
}
