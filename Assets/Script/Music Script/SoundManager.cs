using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    // Start is called before the first frame update
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Update is called once per frame
}
