using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public HealthController healthCon;
    private bool halt;
    private bool stun;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if(halt)
        {
            agent.velocity = new Vector3(0, 0, 0);
        }
        if(healthCon.health != 0)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            halt = true;
        }
    }

    public async void Halt()
    {
        halt = true;
        agent.updateRotation = false;
        if (stun)
        {
            stun = false;
            await Task.Delay(1500);
        }
        else
        {
            await Task.Delay(500);
        }
        if(healthCon.health != 0)
        {
            agent.updateRotation = true;
        }
        halt = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("attack"))
        {
            stun = true;
            Vector3 dir = (transform.position - col.transform.position);
            dir.y = 0;
            dir.Normalize();
            Halt();
            transform.Translate(dir * -3);
        }
        if(col.gameObject.CompareTag("fire"))
        {
            // burn
        }
        if(col.gameObject.CompareTag("ice"))
        {
            // stop moving
            // change render to frozen block
            // enable block behavior script
            // change tag to basicBlock
            // disable this script
        }
    }
}
