using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : GenericSingleton<AudioManager>
{
    [SerializeField] private AudioSource source;
    
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }    
}
