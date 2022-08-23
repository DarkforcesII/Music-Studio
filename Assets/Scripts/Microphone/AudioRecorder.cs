using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class AudioRecorder : MonoBehaviour
{

    public VideoPlayer player;
    public Slider videoSlider;

    public AudioSource[] audioSources;
    public AudioClip[] sunnyClips;
    public AudioClip[] staffrollClips;
    public AudioClip[] attractionClips;

    public bool isPLaying = false;

    public void PauseMusic()
    {
        for (int i = 1; i < audioSources.Length; i++)
        {
            audioSources[i].Pause();
        }
    }

    public void UnpauseMusic()
    {
        for (int i = 1; i < audioSources.Length; i++)
        {
            audioSources[i].Play();
        }
    }

    public void UpdateMusicPosition()
    {
        for (int i = 1; i < audioSources.Length; i++)
        {
            audioSources[i].time = videoSlider.value;
        }
    }

    private void Update()
    {
        PlayMusic();

        if (Input.GetKeyDown(KeyCode.S))
        {
            // audio gets stored in first index in source array
            // so it can be exported as wav file
            SavWav.Save("Sunny", audioSources[0].clip);
        }
    }

    public void RecordMicAudio()
    {
        // to do: create way to change recording length
        audioSources[0].clip = Microphone.Start("Line (USB AUDIO  CODEC)", true, 100, 48000);
        audioSources[0].Play();
    }

    public void PlayMusic()
    {
        if (isPLaying == true)
        {
            isPLaying = false;

            switch (player.clip.name)
            {
                case "Sunny":
                    for (int i = 0; i < sunnyClips.Length; i++)
                    {
                        audioSources[i + 1].clip = sunnyClips[i];
                        audioSources[i + 1].Play();
                    }
                    break;
                case "Staffroll":
                    for (int i = 0; i < staffrollClips.Length; i++)
                    {
                        audioSources[i + 1].clip = staffrollClips[i];
                        audioSources[i + 1].Play();
                    }
                    break;
                case "Attraction":
                    for (int i = 0; i < attractionClips.Length; i++)
                    {
                        audioSources[i + 1].clip = attractionClips[i];
                        audioSources[i + 1].Play();
                    }
                    break;
            }

        }
    }
}
