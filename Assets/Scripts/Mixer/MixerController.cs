using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer masterMixer;
    Slider videoSlider;

    private void Start()
    {
        videoSlider = GetComponent<Slider>();
    }

    public void SetSliderVol(float sliderValue)
    {
        switch (videoSlider.name)
        {
            case "Fader1": masterMixer.SetFloat("Slider1Vol", (Mathf.Log10(sliderValue) * 20)); break;
            case "Fader2": masterMixer.SetFloat("Slider2Vol", (Mathf.Log10(sliderValue) * 20)); break;
            case "Fader3": masterMixer.SetFloat("Slider3Vol", (Mathf.Log10(sliderValue) * 20)); break;
            case "Fader4": masterMixer.SetFloat("Slider4Vol", (Mathf.Log10(sliderValue) * 20)); break;
            case "Fader5": masterMixer.SetFloat("Slider5Vol", (Mathf.Log10(sliderValue) * 20)); break;
        }
    }
}
