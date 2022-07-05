using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    Rigidbody rb;

    AudioSource engineSource;
    public AudioClip[] engineSounds;
    float pitch;

    float timeBetweenChange;

    bool engineOn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        pitch = rb.velocity.magnitude / 15;

        if(engineOn)
        {
            if (pitch < 2)
                engineSource.pitch = pitch;
            else
                engineSource.pitch = 2;
        }

        
    }

    public void StartEngine()
    {
        engineSource.clip = engineSounds[0];
        engineSource.Play();
    }

    public void RunningEngine()
    {
        engineOn = true;
        engineSource.clip = engineSounds[1];
        engineSource.loop = true;
        engineSource.Play();
    }

    public void StopEngine()
    {
        engineOn = false;
        engineSource.Stop();
        engineSource.clip = engineSounds[2];
        engineSource.loop = false;
        engineSource.pitch = 1;
        engineSource.Play();
    }
}
