using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    public door[] doors;
    private bool activated = false;
    private float targetY;
    private float origY;
    public GameObject PressurePlate;

    // Start is called before the first frame update
    void Start()
    {
        targetY = PressurePlate.transform.position.y - 0.25f;
        origY = PressurePlate.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (PressurePlate.transform.position.y > targetY)
            {
                PressurePlate.transform.Translate(Vector3.down * Time.deltaTime);
            }
            
        }
        else
        {
            if (PressurePlate.transform.position.y < origY)
            {
                PressurePlate.transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("basicBlock"))
        {
            activated = true;
            foreach (door door in doors)
            {
                door.activated = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("basicBlock"))
        {
            activated = false;
            foreach (door door in doors)
            {
                door.activated = false;
            }
        }
    }
}
