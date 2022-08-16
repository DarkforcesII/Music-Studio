using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CustomAudioManager : MonoBehaviour
{
    public AudioSource uiSource;
    public AudioClip clickSound;

    // color
    public Renderer[] whiteKeyRenderers;
    public Renderer[] blackKeyRenderers;
    public float resetColorTimer = 0.5f;

    // UI click
    public void PlayUIClick()
    {
        uiSource.volume = 0.7f;
        uiSource.PlayOneShot(clickSound);
    }
}
