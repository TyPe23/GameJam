using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    public BoxCollider spikeHB;

    public async void ActiveSpike()
    {
        await Task.Delay(1000);
        spikeHB.enabled = true;
        await Task.Delay(1000);
        spikeHB.enabled = false;
    }
}
