using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawns : MonoBehaviour
{
    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("checkpoint"))
        {
            spawnPoint = other.transform.position;
        }
    }

    public void respawn()
    {
        transform.position = spawnPoint;
    }
}
