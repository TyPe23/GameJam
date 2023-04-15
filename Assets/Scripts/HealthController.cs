using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int health = 3;

    void Update()
    {
        if(health == 0)
        {
            // die
            Destroy(gameObject); // temp
        }
    }

    private async void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("spikes"))
        {
            // knockback
            health -= 1;
        }
        if(col.gameObject.CompareTag("enemy"))
        {
            EnemyBehavior enemy = col.gameObject.GetComponent<EnemyBehavior>();
            enemy.Halt();
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(rb.velocity * -5, ForceMode.Impulse);
            await Task.Delay(10);
            health -= 1;
        }
    }
}