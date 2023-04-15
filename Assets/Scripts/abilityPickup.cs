using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityPickup : MonoBehaviour
{
    public abilities ability;
    public ThirdPersonController player;

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.CompareTag("Player"))
        {
            player.ability = ability;
            Destroy(gameObject);
        }
    }
}

public enum abilities
{
    dash,
    ice,
    fire,
    attack,
}