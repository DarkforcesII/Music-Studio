using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SliderController : MonoBehaviour
{
    public Slider videoSlider;
    public VideoPlayer player;
    public VideoClip[] videoClips;

    public AudioRecorder audioRecorderScript;

    public void SelectVideoClip(int i)
    {
        audioRecorderScript.isPLaying = true;

        switch (i)
        {
            case 0:
                player.Stop(); 
                break;
            case 1:
                player.Stop();
                player.clip = videoClips[0];
                player.time = 0;
                videoSlider.maxValue = (float)player.clip.length;
                player.Play();
                break;
            case 2:
                player.Stop();
                player.clip = videoClips[1];
                player.time = 0;
                videoSlider.maxValue = (float)player.clip.length;
                player.Play();
                break;
            case 3:
                player.Stop();
                player.clip = videoClips[2];
                player.time = 0;
                videoSlider.maxValue = (float)player.clip.length;
                player.Play();
                break;
            case 4:
                player.Stop();
                player.clip = videoClips[3];
                player.time = 0;
                videoSlider.maxValue = (float)player.clip.length;
                player.Play();
                break;
        }
    }
    
    public void UpdateSliderPosition()
    {
        player.time = videoSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlaying == true)
        {
            videoSlider.value = (float)player.time;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioRecorderScript.isPLaying = true;
            player.clip = videoClips[0];
            player.time = 0;
            videoSlider.maxValue = (float)player.clip.length;
            player.Play();
            audioRecorderScript.RecordMicAudio();
        }
    }
}
