using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    bool isMusicOn;

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

    private void PlayerMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void MuteMusic()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
