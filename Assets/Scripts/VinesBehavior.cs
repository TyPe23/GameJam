using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinesBehavior : MonoBehaviour
{
    public Material mat;
    public GameObject particles;
    private bool lit = false;
    private float lerp = 0;

    void Start()
    {
        mat.SetFloat("_DissolveAmount", 0);
    }

    void FixedUpdate()
    {
        if(lit)
        {
            if(lerp <= 1)
            {
                lerp += (Time.fixedDeltaTime * 0.1f);
            }
            mat.SetFloat("_DissolveAmount", lerp);
            print(mat.GetFloat("_DissolveAmount"));
            print(Mathf.Lerp(0, 0.7f, Time.fixedDeltaTime));
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("fire"))
        {
            if (!lit)
            {
                StartCoroutine(SetFire());
            }
        }
    }

    public IEnumerator SetFire()
    {
        lit = true;
        particles.SetActive(true);
        yield return new WaitForSeconds(2);
        gameObject.tag = "fire";
        StartCoroutine(PutOut());
    }

    public IEnumerator PutOut()
    {
        yield return new WaitForSeconds(3);
        particles.SetActive(false);
    }
}
