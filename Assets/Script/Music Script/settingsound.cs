using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsound : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    // Start is called before the first frame update
    private void Awake()
    {
        musicSource.enabled = Sound.GetSoundOn();
    }

    // Update is called once per frame
    public void onclick()
    {
        if (Sound.GetSoundOn())
        {
            Sound.SetSoundOn(false);

        }
        else
        {
            Sound.SetSoundOn(true);
        }
        transform.GetChild(0).gameObject.SetActive(Sound.GetSoundOn());
        musicSource.enabled = Sound.GetSoundOn();
    }
}
