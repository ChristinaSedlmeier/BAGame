using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;

    public static SoundManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s== null)
        {
            return;
        }
        s.source.Play();
    }


    public void Stop()
    {
        
        foreach (Sound s in sounds)
        {
            float startVolume = s.volume;

            while (s.volume > 0)
            {
                s.volume -= startVolume * 0.01f;



            }
            s.source.Stop();
            s.volume = startVolume;
        }
    }



}
