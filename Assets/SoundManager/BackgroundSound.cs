using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    public AudioClip[] _tracks;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    void PlayTrack()
    {
        int index = Random.Range(0, _tracks.Length - 1);
        _audioSource.clip = _tracks[index];
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_audioSource.isPlaying)
        {
            PlayTrack();
        }
    }
}
