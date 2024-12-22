using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    [Range(0,1)]
    public float volume;

    public void PlayClip()
    {
        if (audioClip == null)
            return;
        audioSource.PlayOneShot(audioClip, volume);
    }

}
