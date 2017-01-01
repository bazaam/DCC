using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void SetVolume (float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
}