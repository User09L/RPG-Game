using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    //public AudioSource jumpingsound,arrowhit;
    public static AudioClip jumpsound,arrowhit,spike,coins;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpsound = Resources.Load<AudioClip> ("jumpsound");
        arrowhit = Resources.Load<AudioClip> ("arrowhit");
        spike = Resources.Load<AudioClip> ("spike");
        coins =  Resources.Load<AudioClip> ("coins");
        audioSrc = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jumpsound":
                audioSrc.PlayOneShot (jumpsound);
                break;
            case "arrowhit":
                audioSrc.PlayOneShot (arrowhit);
                break;
            case "spike":
                audioSrc.PlayOneShot (spike);
                break;
            case "coins":
                audioSrc.PlayOneShot (coins);
                break;
        }
    }
}
