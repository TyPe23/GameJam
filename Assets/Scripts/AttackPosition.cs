using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPosition : MonoBehaviour
{
    public HealthController healthCon;
    private Transform attackPos;

    void Start()
    {
        GameObject attack = GameObject.FindWithTag("attackPos");
        attackPos = attack.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if(healthCon.health != 0)
        {
            gameObject.transform.position = attackPos.position;
        }
    }
}