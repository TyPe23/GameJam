using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    private bool isMoving, isBurning, isFrozen, hasPushed, hasShattered;

    void FixedUpdate()
    {
        if(isMoving)
        {
            // dependent on player orientation
            gameObject.transform.Translate(Vector3.left * 0.5f);
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
        if(col.gameObject.CompareTag("basicPunch") && gameObject.CompareTag("basicBlock") && !hasPushed)
        {
            isMoving = true;
            hasPushed = true;
        }
        else if(col.gameObject.CompareTag("firePunch") && gameObject.CompareTag("vines") && !isBurning)
        {
            isBurning = true;
            Burn();
        }
        else if(col.gameObject.CompareTag("icePunch") && gameObject.CompareTag("heavyBlock") && !hasShattered)
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
            isMoving = false;
        }
    }

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