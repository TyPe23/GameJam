using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedSpikes : MonoBehaviour
{
    private bool active;
    public GameObject spikeHB;
    private bool flipped;
    public GameObject spikes;
    private Transform origPos;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        origPos = spikes.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!flipped)
            {
                spikeHB.SetActive(true);
                spikes.transform.position = origPos.position + new Vector3(0, 0.5f, 0);
                StartCoroutine(flip());
            }
        }
        else
        {
            if (!flipped)
            {
                spikeHB.SetActive(false);
                spikes.transform.position = origPos.position - new Vector3(0, 0.5f, 0);
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
