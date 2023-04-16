using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public GameObject dustParticles;
    public Transform player;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ice") && gameObject.CompareTag("basicBlock"))
        {
            rb = GetComponent<Rigidbody>();
            Vector3 dir = (transform.position - player.position);
            dir.y = 0;
            rb.AddForce(dir * 200);
            Game.globalInstance.sndPlayer.PlaySound(SoundType.ICE_SLIDE, GetComponent<AudioSource>());
        }
        else if (col.gameObject.CompareTag("ice") && gameObject.CompareTag("enemy"))
        {
            ChangeTag();
            Game.globalInstance.sndPlayer.PlaySound(SoundType.ICE_FREEZE, GetComponent<AudioSource>());
        }
        else if (col.gameObject.CompareTag("attack") && gameObject.CompareTag("heavyBlock"))
        {
            dustParticles.SetActive(true);
            Destroy(gameObject);
            Game.globalInstance.sndPlayer.PlaySound(SoundType.ROCK_BREAK, GetComponent<AudioSource>());
        }
    }

    private async void ChangeTag()
    {
        await Task.Delay(300);
        gameObject.tag = "basicBlock";
    }
}