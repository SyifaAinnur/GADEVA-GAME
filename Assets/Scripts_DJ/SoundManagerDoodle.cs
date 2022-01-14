using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerDoodle : MonoBehaviour
{
    public static AudioClip bounceSound, crackSound, dblbounceSound, enemySound, themeSound, shootSound, explodeSound, planeSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        bounceSound = Resources.Load<AudioClip>("Bounce");
        crackSound = Resources.Load<AudioClip>("Crack");
        dblbounceSound = Resources.Load<AudioClip>("DoubleBounce");
        enemySound = Resources.Load<AudioClip>("Enemy");
        themeSound = Resources.Load<AudioClip>("Theme");
        shootSound = Resources.Load<AudioClip>("Shoot");
        explodeSound = Resources.Load<AudioClip>("Explode");
        planeSound = Resources.Load<AudioClip>("Plane");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "bounce":
                audioSrc.PlayOneShot(bounceSound);
                break;
            case "crack":
                audioSrc.PlayOneShot(crackSound);
                break;
            case "dblbounce":
                audioSrc.PlayOneShot(dblbounceSound);
                break;
            case "enemy":
                audioSrc.PlayOneShot(enemySound);
                //audioSrc.spatialBlend = 1;
                //audioSrc.loop = true;
                break;
            case "theme":
                audioSrc.clip = themeSound;
                audioSrc.loop = true;
                audioSrc.Play();
                break;
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "explode":
                audioSrc.PlayOneShot(explodeSound);
                break;
            case "plane":
                audioSrc.clip = planeSound;
                audioSrc.loop = true;
                audioSrc.Play();
                break;
            case "themetransition":
                audioSrc.PlayOneShot(themeSound);
                break;
        }
    }
}
