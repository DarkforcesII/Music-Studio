using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RecordAudio : MonoBehaviour
{

    public VideoPlayer player;
    AudioSource micSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void RecordMicAudio()
    {
        // to do: create way to change recording length
        micSource = GetComponent<AudioSource>();
        micSource.clip = Microphone.Start("Line (USB AUDIO  CODEC)", true, 100, 48000);
        micSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavWav.Save("Sunny", micSource.clip);
        }
    }
}
