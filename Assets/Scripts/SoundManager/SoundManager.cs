using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource[] soundEffects;
    private void Awake()
    {
        instance = this;
    }

    public void PlayTheSoundEffect(int soundNo)
    {
        soundEffects[soundNo].Stop();
        soundEffects[soundNo].Play();
    }

    public void PlayTheSoundEffectOnce(int soundNo)
    {
        if (!soundEffects[soundNo].isPlaying)
        {
            soundEffects[soundNo].Play();
        }
    }


}
