using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public HealthController healthCon;
    private Rigidbody rb;
    private bool halt;
    private bool stun;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(halt)
        {
            agent.velocity = new Vector3(0, 0, 0);
        }
        else if(healthCon.health != 0)
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
        if (stun)
        {
            await Task.Delay(200);
            rb.isKinematic = true;
            rb.isKinematic = false;
            stun = false;
            await Task.Delay(1000);
            agent.enabled = true;
        }
        else
        {
            await Task.Delay(500);
        }
        if (healthCon.health == 0)
        {
            agent.enabled = false;
        }
        halt = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("attack"))
        {
            agent.enabled = false;
            stun = true;
            Vector3 dir = (transform.position - target.position);
            dir.y = 0;
            dir.Normalize();
            rb.AddForce(dir * 400);
            Halt();
        }
        if(col.gameObject.CompareTag("fire"))
        {
            // burn
            Destroy(gameObject); // temp
        }
        if(col.gameObject.CompareTag("ice"))
        {
            agent.enabled = false;
            halt = true;
            // change render to frozen block
            BlockBehavior block = gameObject.GetComponent<BlockBehavior>();
            EnemyBehavior enemy = gameObject.GetComponent<EnemyBehavior>();
            gameObject.tag = "basicBlock";
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            block.enabled = true;
            enemy.enabled = false;
        }
    }
}
