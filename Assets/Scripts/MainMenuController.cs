using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    Slider volumeSlider;
    [SerializeField]
    AudioMixer audioMixer;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Volume.SetVolume(volumeSlider.value);
        audioMixer.SetFloat("MasterVolume", Volume.volumeLevel);
    }

    public void onClickPlay()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void onClickExit()
    {
        Debug.Log("goodbye");
        Application.Quit();
    }
}
