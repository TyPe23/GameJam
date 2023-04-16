using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivatedSwitch : MonoBehaviour
{
    public bool active = false;
    public door[] doors;

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("fire"))
        {
            active = true;
            foreach (door door in doors)
            {
                door.activated = true;
            }
        }
    }
}
