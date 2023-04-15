using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    private void OnTriggerEnter(Collider col)
    {
        agent.enabled = true;
    }
}
