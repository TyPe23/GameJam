using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private ThirdPersonController charCon;
    private bool invul;

    private void Start()
    {
        charCon = GetComponent<ThirdPersonController>();
    }

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
        if(col.gameObject.CompareTag("spikes") && !invul)
        {
            // knockback
            //charCon.Knockback((transform.position - col.transform.position));
            invul = true;
            charCon.Knockback((col.transform.position - transform.position));
            health -= 1;
            StartCoroutine(IFrames());
        }
        if(col.gameObject.CompareTag("enemy") && !invul)
        {
            invul = true;
            EnemyBehavior enemy = col.gameObject.GetComponent<EnemyBehavior>();
            enemy.Halt();
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(rb.velocity * -5, ForceMode.Impulse);
            await Task.Delay(10);
            health -= 1;
            StartCoroutine(IFrames());
        }
    }

    private IEnumerator IFrames()
    {
        yield return new WaitForSeconds(1);
        invul = false;
    }
}