using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityPickup : MonoBehaviour
{
    public bool dash;
    public ThirdPersonController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player._dash = dash;
            player._attack = !dash;
            Destroy(gameObject);
        }
    }
}
