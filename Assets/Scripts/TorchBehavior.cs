using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject torchLight, particles;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("fire"))
        {
            torchLight.SetActive(true);
            particles.SetActive(true);
        }
    }
}
