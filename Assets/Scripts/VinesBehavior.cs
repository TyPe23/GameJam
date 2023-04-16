using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinesBehavior : MonoBehaviour
{
    private bool lit = false;

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("fire"))
        {
            if (!lit)
            {
                StartCoroutine(SetFire());
            }
        }
    }

    public IEnumerator SetFire()
    {
        lit = true;
        yield return new WaitForSeconds(2);
        gameObject.tag = "fire";
    }
}
