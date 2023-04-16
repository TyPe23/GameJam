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
            if (ability == abilities.dash) {
                Game.globalInstance.sndPlayer.PlaySound(SoundType.DASH_PICKUP, GetComponent<AudioSource>());
            }
            if (ability == abilities.ice)
            {
                Game.globalInstance.sndPlayer.PlaySound(SoundType.ICE_PICKUP, GetComponent<AudioSource>());
            }
            if (ability == abilities.fire)
            {
                Game.globalInstance.sndPlayer.PlaySound(SoundType.FIRE_PICKUP, GetComponent<AudioSource>());
            }
            if (ability == abilities.attack)
            {
                Game.globalInstance.sndPlayer.PlaySound(SoundType.ATTACK, GetComponent<AudioSource>());
            }

            Destroy(gameObject);
        }
    }
}

public enum abilities
{
    none,
    dash,
    ice,
    fire,
    attack,
}