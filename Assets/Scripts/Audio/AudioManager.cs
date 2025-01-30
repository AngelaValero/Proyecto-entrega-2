using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource =GetComponent<AudioSource>();
    }

    public void ReproducirSonido (AudioClip audio)
    {
        audioSource.PlayOneShot (audio);
    }
}
