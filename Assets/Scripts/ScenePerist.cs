using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePerist : MonoBehaviour
{
    int startSceneIndex;
    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePerist>().Length;
        if (numScenePersist > 1)
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
        startSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
