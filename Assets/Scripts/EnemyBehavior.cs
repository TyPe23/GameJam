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
        await Task.Delay(500);
        if(healthCon.health != 0)
        {
            agent.updateRotation = true;
        }
        halt = false;
    }
}
