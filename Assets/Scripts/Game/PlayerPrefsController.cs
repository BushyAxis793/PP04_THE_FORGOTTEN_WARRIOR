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

    //Mute Music
    const string MUTE_MUSIC_KEY = "mute";

    //Resolution
    const string RESOLUTION_KEY = "resolution";

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
    public static void SetResolution(int res)
    {

        switch (res)
        {
            case 0:

                PlayerPrefs.SetInt(RESOLUTION_KEY, res);
                break;

            case 1:

                PlayerPrefs.SetInt(RESOLUTION_KEY, res);
                break;

            case 2:

                PlayerPrefs.SetInt(RESOLUTION_KEY, res);
                break;

        }
    }
    public static int GetResolution()
    {
        return PlayerPrefs.GetInt(RESOLUTION_KEY);
    }

}
