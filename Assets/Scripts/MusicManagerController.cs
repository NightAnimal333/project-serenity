using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerController : MonoBehaviour
{
    // Start is called before the first frame update

    public enum Theme
    {
        Dark,
        Light,
        Broken
    }

    public enum Sound
    {
        IntoSerenity,
        IntoNoise,
        SerenityBlocked,
        Death,
        Hit
    }

    [SerializeField]
    private AudioSource darkAudio;
    [SerializeField]
    private AudioSource lightAudio;
    [SerializeField]
    private AudioSource brokenAudio;

    [SerializeField]
    private AudioSource intoSerenity;
    [SerializeField]
    private AudioSource intoNoise;
    [SerializeField]
    private AudioSource serenityBlocked;
    [SerializeField]
    private AudioSource death;
    [SerializeField]
    private AudioSource hit1;
    [SerializeField]
    private AudioSource hit2;

    int lastHitSound = 1;


    Theme currentTheme;

    void Start()
    {
        currentTheme = Theme.Dark;

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

    public void PlayTheme(Theme theme)
    {
        switch (theme)
        {

            case (Theme.Dark):
            {
                    darkAudio.mute = false;
                    lightAudio.mute = true;
                    brokenAudio.mute = true;
                    break;
            }
            case (Theme.Light):
                {
                    darkAudio.mute = true;
                    lightAudio.mute = false;
                    brokenAudio.mute = true;
                    break;
            }
            case (Theme.Broken):
            {
                    darkAudio.mute = true;
                    lightAudio.mute = true;
                    brokenAudio.mute = false;
                    break;
            }

        }
        currentTheme = theme;
    }

    public void PlaySound(Sound sound)
    {
        switch (sound)
        {
            case Sound.IntoSerenity:
                {
                    intoSerenity.Play();
                    break;
                }
            case Sound.IntoNoise:
                {
                    intoNoise.Play();
                    break;
                }
            case Sound.SerenityBlocked:
                {
                    serenityBlocked.Play();
                    break;
                }
            case Sound.Hit:
                {
                    Debug.Log(lastHitSound);
                    if (lastHitSound == 1)
                    {
                        hit2.Play();
                        lastHitSound = 2;
                    } else
                    {
                        hit1.Play();
                        lastHitSound = 1;
                    }
                    break;
                }
            case Sound.Death:
                {
                    death.Play();
                    break;
                }
        }
    }

}
