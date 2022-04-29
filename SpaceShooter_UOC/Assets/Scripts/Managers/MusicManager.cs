using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    AudioSource musicSource;
    [SerializeField] AudioMixer masterMixer;
    AudioMixerSnapshot pausedSnapshot;
    AudioMixerSnapshot unpausedSnapshot;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        pausedSnapshot = masterMixer.FindSnapshot("Paused");
        unpausedSnapshot = masterMixer.FindSnapshot("Unpaused");
    }

    public void PauseMode(bool isPaused)
    {
        if (isPaused)
        {
            pausedSnapshot.TransitionTo(0.01f);
        }
        else
        {
            unpausedSnapshot.TransitionTo(0.01f);
        }
    }


}
