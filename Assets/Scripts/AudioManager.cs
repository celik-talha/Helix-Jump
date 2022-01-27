using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioClip jumpSFX;
    AudioSource soundSource;
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.playOnAwake = false;
        soundSource.clip = jumpSFX;
    }
    
    public void playJump()
    {
        soundSource.Play ();
    }
}
