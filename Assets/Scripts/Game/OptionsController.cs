using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] Toggle muteToggle;

    int isMute;
    int resolutionIndex;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetVolume();
        resolutionIndex = PlayerPrefsController.GetResolution();
        CheckToggleState();
    }
    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }
    private void CheckToggleState()
    {
        bool toogleOn = false;
        if (PlayerPrefsController.GetMute() == 1)
        {
            toogleOn = true;
        }
        else
        {
            toogleOn = false;
        }

        muteToggle.isOn = toogleOn;
    }
    public void MuteMusic()
    {
        var audioSource = FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>();

        if (muteToggle.isOn)
        {
            isMute = 1;
            audioSource.mute = true;
        }
        else
        {
            isMute = 0;
            audioSource.mute = false;
        }

    }
    public void SwitchResolution()
    {
        resolutionIndex = resolutionDropdown.value;

        switch (resolutionIndex)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;
            case 2:
                Screen.SetResolution(800, 600, true);
                break;
        }
    }
    public void CloseOptions()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
        PlayerPrefsController.SetMute(isMute);
        PlayerPrefsController.SetResolution(resolutionIndex);
        optionsCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }
}