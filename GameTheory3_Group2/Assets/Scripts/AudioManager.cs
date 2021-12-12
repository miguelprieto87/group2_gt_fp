using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource sfxSource;

    public AudioClip canonFire;
    public AudioClip buttonClick;
    public AudioClip ballHitGround;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void playCanonFire()
    {
        Debug.Log("Playing sound");
        sfxSource.PlayOneShot(canonFire);
       
    }

    public void playButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }

    public void playHitGround()
    {
        sfxSource.PlayOneShot(ballHitGround);
    }
}
