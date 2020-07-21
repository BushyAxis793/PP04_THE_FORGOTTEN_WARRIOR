using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetVolume();
    }
    private void PlayerMusic()
    {
        GetComponent<AudioSource>().Play();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
