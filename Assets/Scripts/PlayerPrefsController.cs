using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    //Volume 
    const string VOLUME_KEY = "volume";
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    //Resolution
    const string RESOLUTION_KEY = "resolution";
    int resolutionX;
    int resolutionY;

    //Mute Music
    const string MUTE_MUSIC_KEY = "mute";
    const int MUTE_TRUE = 1;
    const int MUTE_FALSE = 0;


    public static void SetVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }

    public static void SetMute(int mute)
    {
        if (mute == 1)
        {
            PlayerPrefs.SetInt(MUTE_MUSIC_KEY, mute);
        }
        if (mute == 0)
        {
            PlayerPrefs.SetInt(MUTE_MUSIC_KEY, mute);
        }
    }

    public static int GetMute()
    {
        return PlayerPrefs.GetInt(MUTE_MUSIC_KEY);
    }


}
