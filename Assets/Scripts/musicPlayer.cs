﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] music;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private int index = 0;
    void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = music[index];
            audio.Play();
            index++;
            index = index % music.Length;
        }
    }
}
