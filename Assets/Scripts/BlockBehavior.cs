using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    private bool isMoving, isBurning, isFrozen, hasPushed, hasShattered;
    public Transform player;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        if(isMoving)
        {
            // dependent on player orientation
            //gameObject.transform.Translate((transform.position - player.position) * 0.05f);
        }
        if(isBurning)
        {
            // particles
        }
        if(isFrozen)
        {
            // particles
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("attack") && gameObject.CompareTag("basicBlock") && !hasPushed)
        {
            //isMoving = true;
            //hasPushed = true;
            Vector3 dir = (transform.position - player.position);
            dir.y = 0;
            rb.AddForce(dir * 200);
        }
        else if(col.gameObject.CompareTag("fire") && gameObject.CompareTag("vines") && !isBurning)
        {
            isBurning = true;
            Burn();
        }
        else if(col.gameObject.CompareTag("ice") && gameObject.CompareTag("heavyBlock") && !hasShattered)
        {
            if(isFrozen)
            {
                hasShattered = true;
                Shatter();
            }
            else
            {
                isFrozen = true;
            }
        }
    }

    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("wall"))
    //    {
    //        isMoving = false;
    //    }
    //}

    private async void Burn()
    {
        await Task.Delay(500);
        Destroy(gameObject);
    }

    private async void Shatter()
    {
        // particles
        await Task.Delay(500);
        Destroy(gameObject);
    }
}