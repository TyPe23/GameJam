using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    public GameObject spikeHB;
    public int spikeDelayms;
    public bool active = false;
    public GameObject spikes;
    private Transform origPos;

    private void Start()
    {
        origPos = spikes.transform;
    }

    public async void ActiveSpike()
    {
        await Task.Delay(spikeDelayms);
        spikeHB.SetActive(true);
        active = true;
        spikes.transform.position = origPos.position + new Vector3(0, 0.5f, 0);
        Game.globalInstance.sndPlayer.PlaySound(SoundType.SPIKE, GetComponent<AudioSource>());
        await Task.Delay(1000);
        spikes.transform.position = origPos.position - new Vector3(0, 0.5f, 0);
        active = false;
        spikeHB.SetActive(false);
    }
}
