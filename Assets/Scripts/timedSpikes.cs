using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedSpikes : MonoBehaviour
{
    private bool active;
    public GameObject spikeHB;
    private bool flipped;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!flipped)
            {
                spikeHB.SetActive(true);
                StartCoroutine(flip());
            }
        }
        else
        {
            if (!flipped)
            {
                spikeHB.SetActive(false);
                StartCoroutine(flip());
            }
        }
    }

    public IEnumerator flip()
    {
        flipped = true;
        Game.globalInstance.sndPlayer.PlaySound(SoundType.SPIKE, GetComponent<AudioSource>());
        yield return new WaitForSecondsRealtime(2);
        active = !active;
        flipped = false;
    }
}
