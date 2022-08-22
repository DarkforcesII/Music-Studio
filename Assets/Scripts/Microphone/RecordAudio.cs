using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RecordAudio : MonoBehaviour
{

    public VideoPlayer player;

    public AudioSource[] audioSources;
    public AudioClip[] sunnyClips;
    public AudioClip[] staffrollClips;
    public AudioClip[] attractionClips;

    public bool isPLaying = false;

    // Start is called before the first frame update
    void Start()
    {
       
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
                        audioSources[i].clip = sunnyClips[i];
                        audioSources[i].Play();
                    }
                    break;
                case "Staffroll":
                    for (int i = 0; i < staffrollClips.Length; i++)
                    {
                        audioSources[i].clip = staffrollClips[i];
                        audioSources[i].Play();
                    }
                    break;
                case "Attraction":
                    for (int i = 0; i < attractionClips.Length; i++)
                    {
                        audioSources[i].clip = attractionClips[i];
                        audioSources[i].Play();
                    }
                    break;
            }

        }
    }
}
