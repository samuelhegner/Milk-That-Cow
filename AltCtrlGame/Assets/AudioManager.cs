using UnityEngine.Audio;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public float mooTime;
    
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    
    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Update()
    {
        float ran = Random.Range(0f, mooTime * 30);
        if (ran >mooTime - 1)
        {
            Play("Moo");
        }
    }
}
