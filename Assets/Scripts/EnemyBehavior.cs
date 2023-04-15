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
    private bool halt, stun, burn;
    private int mult = 1;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (halt)
        {
            agent.velocity = new Vector3(0, 0, 0);
        }
        else if (burn)
        {
            Invoke(nameof(Run), UnityEngine.Random.Range(1, 3));
        }
        else if (healthCon.health != 0)
        {
            agent.speed = 3.5f;
            agent.SetDestination(target.position);
        }
        else
        {
            halt = true;
        }
    }

    void Run()
    {
        Vector3 runTo = transform.position + ((transform.position - target.position + new Vector3(UnityEngine.Random.Range(-12, 12), 0, UnityEngine.Random.Range(-15, 12)) * mult));
        agent.speed = UnityEngine.Random.Range(3.5f, 7f);
        agent.SetDestination(runTo);
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
        if(col.gameObject.CompareTag("attack") && !stun)
        {
            agent.enabled = false;
            stun = true;
            Vector3 dir = (transform.position - target.position);
            dir.y = 0;
            dir.Normalize();
            rb.AddForce(dir * 400);
            Halt();
        }
        if(col.gameObject.CompareTag("fire") && !burn)
        {
            agent.velocity = new Vector3(0, 0, 0);
            Invoke(nameof(Run), 0.1f);
            burn = true;
            StopBurning();
        }
        if(col.gameObject.CompareTag("ice"))
        {
            agent.enabled = false;
            halt = true;
            // change render to frozen block
            BlockBehavior block = gameObject.GetComponent<BlockBehavior>();
            EnemyBehavior enemy = gameObject.GetComponent<EnemyBehavior>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            enemy.enabled = false;
        }
    }

    private async void StopBurning()
    {
        await Task.Delay(5000);
        burn = false;
    }
}
