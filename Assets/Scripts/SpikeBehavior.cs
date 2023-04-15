using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    public GameObject spikeHB;
    public int spikeDelayms;

    public async void ActiveSpike()
    {
        await Task.Delay(spikeDelayms);
        spikeHB.SetActive(true);
        await Task.Delay(1000);
        spikeHB.SetActive(false);
    }
}
