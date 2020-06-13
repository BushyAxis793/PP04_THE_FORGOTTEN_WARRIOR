using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject pauseCanvas;

    bool isOptionsAcitve;
    int isMute;

    Toggle muteToggle;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetVolume();
        isMute = PlayerPrefsController.GetMute();
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

    public void MuteMusic()
    {
        FindObjectOfType<MusicPlayer>().MuteAudioSource();
        if (muteToggle.isOn)
        {
            PlayerPrefsController.SetMute(1);
        }
        else
        {
            PlayerPrefsController.SetMute(0);
        }
    }

    public void CloseOptions()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
        PlayerPrefsController.SetMute(isMute);
        optionsCanvas.SetActive(false);
        pauseCanvas.SetActive(true);

    }
}