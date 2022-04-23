using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    AudioSource musicSource;
    AudioMixer masterMixer;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void PauseMode()
    {

    }


}
