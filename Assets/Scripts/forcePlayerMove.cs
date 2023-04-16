using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcePlayerMove : MonoBehaviour
{
    private bool forceMove;
    private CharacterController charCon;
    private Animator Animator;
    private ThirdPersonController TPCon;
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
        TPCon = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (forceMove)
        {
            charCon.Move(dir * TPCon.SprintSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("forceMove"))
        {
            forceMove = true;
            Animator.SetFloat("Speed", TPCon.SprintSpeed);
            TPCon.enabled = false;
        }
    }
}
