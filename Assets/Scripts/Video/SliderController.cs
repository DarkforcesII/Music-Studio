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

    public void SelectVideoClip(int i)
    {
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
        }
    }
    
    public void UpdateSliderPosition()
    {
        player.time = videoSlider.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlaying == true)
        {
            videoSlider.value = (float)player.time;
        }
    }
}