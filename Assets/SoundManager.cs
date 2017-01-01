using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private float masterVolume;
    AudioSource[] allAudio;

    private void Start()
    {
        
    }
    public void SetMasterVolume (float newVal)
    {
        allAudio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudio)
        {
            
            audio.volume = newVal;
        }

        masterVolume = newVal;
    }
}