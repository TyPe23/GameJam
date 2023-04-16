using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateSpikes : MonoBehaviour
{
    public BoxCollider[] spikes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("basicBlock"))
        {
            foreach (BoxCollider spike in spikes)
            {
                spike.enabled = false;
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("basicBlock"))
    //    {
    //        foreach (BoxCollider spike in spikes)
    //        {
    //            spike.enabled = true;
    //        }
    //    }
    //}
}
