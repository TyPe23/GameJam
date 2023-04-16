using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinesBehavior : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("fire"))
        {
            gameObject.tag = "fire";
        }
    }
}
