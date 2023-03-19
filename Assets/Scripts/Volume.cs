using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Volume
{

    public static float volumeLevel = 0f;

    public static void SetVolume(float newVolume)
    {
        volumeLevel = newVolume*20 - 20;

        if (newVolume <= 0.05f)
        {
            volumeLevel = -80f;
        }
    }


}
