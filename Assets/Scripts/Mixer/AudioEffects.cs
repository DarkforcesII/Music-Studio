using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioEffects : MonoBehaviour
{

    public AudioMixer masterMixer;

    Button chorusFXButton;
    Button lowpassFXButton;

    private bool isChorusEnabled = false;
    private bool isLowpassEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        chorusFXButton = GetComponent<Button>();
        lowpassFXButton = GetComponent<Button>();   
        chorusFXButton.onClick.AddListener(ToggleChorusFX);
        lowpassFXButton.onClick.AddListener(ToggleLowpassFX);
    }

    public void ToggleChorusFX()
    {
        switch (gameObject.name)
        {
            case "Chorus1Button": 
                if (isChorusEnabled == true)
                {
                    masterMixer.SetFloat("ChorusWet1", -80);
                    isChorusEnabled = false;
                    break;
                }
                else 
                {
                    masterMixer.SetFloat("ChorusWet1", 0); 
                    isChorusEnabled = true;
                    break; 
                }
            case "Chorus2Button":
                if (isChorusEnabled == true)
                {
                    masterMixer.SetFloat("ChorusWet2", -80);
                    isChorusEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("ChorusWet2", 0);
                    isChorusEnabled = true;
                    break;
                }
            case "Chorus3Button":
                if (isChorusEnabled == true)
                {
                    masterMixer.SetFloat("ChorusWet3", -80);
                    isChorusEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("ChorusWet3", 0);
                    isChorusEnabled = true;
                    break;
                }
            case "Chorus4Button":
                if (isChorusEnabled == true)
                {
                    masterMixer.SetFloat("ChorusWet4", -80);
                    isChorusEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("ChorusWet4", 0);
                    isChorusEnabled = true;
                    break;
                }
            case "Chorus5Button":
                if (isChorusEnabled == true)
                {
                    masterMixer.SetFloat("ChorusWet5", -80);
                    isChorusEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("ChorusWet5", 0);
                    isChorusEnabled = true;
                    break;
                }
        }
    }

    public void ToggleLowpassFX()
    {
        switch (gameObject.name)
        {
            case "Lowpass1Button":
                if (isLowpassEnabled == true)
                {
                    masterMixer.SetFloat("LowpassFreq1", 22000);
                    isLowpassEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("LowpassFreq1", 5000);
                    isLowpassEnabled = true;
                    break;
                }
            case "Lowpass2Button":
                if (isLowpassEnabled == true)
                {
                    masterMixer.SetFloat("LowpassFreq2", 22000);
                    isLowpassEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("LowpassFreq2", 5000);
                    isLowpassEnabled = true;
                    break;
                }
            case "Lowpass3Button":
                if (isLowpassEnabled == true)
                {
                    masterMixer.SetFloat("LowpassFreq3", 22000);
                    isLowpassEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("LowpassFreq3", 5000);
                    isLowpassEnabled = true;
                    break;
                }
            case "Lowpass4Button":
                if (isLowpassEnabled == true)
                {
                    masterMixer.SetFloat("LowpassFreq4", 22000);
                    isLowpassEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("LowpassFreq4", 5000);
                    isLowpassEnabled = true;
                    break;
                }
            case "Lowpass5Button":
                if (isLowpassEnabled == true)
                {
                    masterMixer.SetFloat("LowpassFreq5", 22000);
                    isLowpassEnabled = false;
                    break;
                }
                else
                {
                    masterMixer.SetFloat("LowpassFreq5", 5000);
                    isLowpassEnabled = true;
                    break;
                }
        }
    }
}
