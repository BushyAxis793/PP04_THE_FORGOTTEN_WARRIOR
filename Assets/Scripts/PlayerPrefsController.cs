using System.Collections;
using System.Collections.Generic;
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

    

}
