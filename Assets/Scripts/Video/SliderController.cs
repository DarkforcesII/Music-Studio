using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SliderController : MonoBehaviour
{
    public Slider videoSlider;
    public VideoPlayer player;
    
    public void UpdateSliderPosition()
    {
        player.time = videoSlider.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        videoSlider.maxValue = (float)player.clip.length;
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
