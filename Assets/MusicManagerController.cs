using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerController : MonoBehaviour
{
    // Start is called before the first frame update

    public enum Audio
    {
        Dark,
        Light,
        Broken
    }

    [SerializeField]
    private AudioSource darkAudio;
    [SerializeField]
    private AudioSource lightAudio;
    [SerializeField]
    private AudioSource brokenAudio;

    Audio currentTheme;

    void Start()
    {
        currentTheme = Audio.Dark;

        darkAudio.Play();
        lightAudio.Play();
        lightAudio.mute = true;
        brokenAudio.Play();
        brokenAudio.mute = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTheme(Audio theme)
    {
        switch (theme)
        {

            case (Audio.Dark):
            {
                    darkAudio.mute = false;
                    lightAudio.mute = true;
                    brokenAudio.mute = true;
                    break;
            }
            case (Audio.Light):
                {
                    darkAudio.mute = true;
                    lightAudio.mute = false;
                    brokenAudio.mute = true;
                    break;
            }
            case (Audio.Broken):
            {
                    darkAudio.mute = true;
                    lightAudio.mute = true;
                    brokenAudio.mute = false;
                    break;
            }

        }
    }

}
