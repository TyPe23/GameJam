using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public EnemyBehavior enemy;
    public UnityEngine.AI.NavMeshAgent agent;

    private void OnTriggerEnter(Collider col)
    {
        enemy.enabled = true;
        agent.enabled = true;
    }
}
