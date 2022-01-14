using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sound
{
    private static bool soundOn = true;
    public static void SetSoundOn(bool on)
    {
        soundOn = on;
    }
    public static bool GetSoundOn()
    {
        return soundOn;
    }
}
