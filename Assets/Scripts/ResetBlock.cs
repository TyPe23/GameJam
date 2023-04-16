using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBlock : MonoBehaviour
{
    public Transform room1;
    public Transform room2;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("basicBlock"))
        {
            if(gameObject.CompareTag("room"))
            {
                col.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                col.transform.position = room1.position;
            }
            else
            {
                col.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                col.transform.position = room2.position;
            }
        }
    }
}
