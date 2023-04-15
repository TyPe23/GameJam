using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    private bool isBurning;
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
        }
        else if (col.gameObject.CompareTag("ice") && gameObject.CompareTag("enemy"))
        {
            ChangeTag();
        }
        else if (col.gameObject.CompareTag("attack") && gameObject.CompareTag("heavyBlock"))
        {
            // particles
            Destroy(gameObject);
        }
    }

    private async void ChangeTag()
    {
        await Task.Delay(300);
        gameObject.tag = "basicBlock";
    }
}