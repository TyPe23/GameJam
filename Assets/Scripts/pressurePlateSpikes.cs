using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateSpikes : MonoBehaviour
{
    public BoxCollider[] spikes;
    private bool activated = false;
    private float targetY;
    public GameObject PressurePlate;

    // Start is called before the first frame update
    void Start()
    {
        targetY = PressurePlate.transform.position.y - 0.25f;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("basicBlock"))
        {
            activated = true;
            foreach (BoxCollider spike in spikes)
            {
                spike.enabled = false;
            }
            Game.globalInstance.sndPlayer.PlaySound(SoundType.PLAYER_FEEDBACK, GetComponent<AudioSource>());
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("basicBlock"))
    //    {
    //        foreach (BoxCollider spike in spikes)
    //        {
    //            spike.enabled = true;
    //        }
    //    }
    //}
}
