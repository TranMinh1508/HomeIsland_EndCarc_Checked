using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public Sound[] Sounds;
    public List<AudioSource> audioSources = new List<AudioSource>();

    public void PlaySound(string name, bool loop)
    {
        Sound s = Array.Find(Sounds, x => x.name == name);
        if (s == null)
        {
            return;
        }
        else
        {
            AudioSource source = GetAvailableAudioSource();
            source.clip = s.clip;
            source.Play();
            source.loop = loop;
        }
    }

    private AudioSource GetAvailableAudioSource()
    {
        AudioSource availableSource = audioSources.Find(source => !source.isPlaying);
        if (availableSource == null)
        {
            availableSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(availableSource);
        }
        return availableSource;
    }
}

