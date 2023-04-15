using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private bool goRight, goLeft, halt;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ChangeDirections();
    }

    void FixedUpdate()
    {
        if(goRight)
        {
            rb.velocity = new Vector3(5, 0, 0);
        }
        if(goLeft)
        {
            rb.velocity = new Vector3(-5, 0, 0);
        }
    }

    private async void ChangeDirections()
    {
        if(!halt)
        {
            goRight = true;
            await Task.Delay(1000);
            goRight = false;
        }
        else
        {
            await Task.Delay(200);
        }
        if(!halt)
        {
            goLeft = true;
            await Task.Delay(1000);
            goLeft = false;
        }
        else
        {
            await Task.Delay(200);
        }
        ChangeDirections();
    }

    public async void Halt()
    {
        halt = true;
        goRight = false;
        goLeft = false;
        await Task.Delay(500);
        halt = false;
    }
}
