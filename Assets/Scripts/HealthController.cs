using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class HealthController : MonoBehaviour
{
    public int health = 3;
    private ThirdPersonController charCon;
    private bool invul;
    private respawns spawns;

    private void Start()
    {
        charCon = GetComponent<ThirdPersonController>();
        spawns = GetComponent<respawns>();
    }

    void Update()
    {
        if(health == 0)
        {
            // die
            Destroy(gameObject); // temp
            SceneManager.LoadScene("End Scene");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        print(col.name);
        if (col.gameObject.CompareTag("spikes") && !invul)
        {
            print("Spikes!");
            SpikeBehavior spikes = col.gameObject.GetComponent<SpikeBehavior>();
            spikes.ActiveSpike();
        }
        if (col.gameObject.CompareTag("spikesHB") && !invul)
        {
            health -= 1;
            invul = true;

            charCon.enabled = false;

            //Vector3 dir = (transform.position - col.transform.position);
            //dir.y = 0;
            //dir.Normalize();
            //transform.Translate(dir);

            StartCoroutine(Wait());
            StartCoroutine(IFrames());
        }
        if (col.gameObject.CompareTag("enemy") && !invul)
        {
            invul = true;
            EnemyBehavior enemy = col.gameObject.GetComponent<EnemyBehavior>();
            enemy.Halt();
            if (health != 1)
            {
                Vector3 dir = (transform.position - col.transform.position);
                dir.y = 0;
                dir.Normalize();
                col.transform.Translate(dir * 3);
            }
            health -= 1;
            StartCoroutine(IFrames());
        }
    }

    private IEnumerator IFrames()
    {
        yield return new WaitForSeconds(0.25f);
        spawns.respawn();
        invul = false;
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        charCon.enabled = true;
    }
}