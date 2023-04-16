using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject torchLight, particles;
    private bool lit = false;

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("fire") && !lit)
        {
            lit = true;
            torchLight.SetActive(true);
            particles.SetActive(true);
        }
    }
}
