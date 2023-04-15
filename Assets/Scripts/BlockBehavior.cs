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

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("ice") && gameObject.CompareTag("basicBlock"))
        {
            Vector3 dir = (transform.position - player.position);
            dir.y = 0;
            rb.AddForce(dir * 200);
        }
        else if(col.gameObject.CompareTag("fire") && gameObject.CompareTag("vines") && !isBurning)
        {
            isBurning = true;
            Burn();
        }
        else if(col.gameObject.CompareTag("attack") && gameObject.CompareTag("heavyBlock"))
        {
            // particles
            Destroy(gameObject);
        }
    }

    private async void Burn()
    {
        // particles on
        await Task.Delay(500);
        // particles off
        Destroy(gameObject);
    }
}