using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool activated;
    private float targetY;
    private float origY;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        targetY = transform.position.y - 3;
        origY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (transform.position.y > targetY)
            {
                Game.globalInstance.sndPlayer.PlayOnce(SoundType.DOOR, GetComponent<AudioSource>());
                transform.Translate(Vector3.down * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y < origY)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
            }
        }
    }
}
