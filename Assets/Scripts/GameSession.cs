using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Boo.Lang;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;



    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject OptionsCanvas;

   
    bool isPauseActive;




    private void Start()
    {

        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        DebugRestartLevel();
        PauseGame();
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        //int numGameSessions = FindObjectsOfType<GameSession>().Length;
        //if (numGameSessions > 1)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
    }

    public void PlayerDeath()
    {
        if (lives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGame();
        }
    }

    private void TakeLife()
    {
        lives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        livesText.text = lives.ToString();
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }


    private void DebugRestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    

    public void PauseGame()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            isPauseActive = !isPauseActive;
            if (isPauseActive)
            {
                Time.timeScale = 0f;
                PauseCanvas.SetActive(true);

            }
            else
            {
                Time.timeScale = 1f;
                PauseCanvas.SetActive(false);
            }
        }
    }

    public void OpenOptionsMenu()
    {
        PauseCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void SetResolution(int resolution)
    {
        if (resolution == 0)
        {
            Screen.SetResolution(1920, 1080, true);

        }
        if (resolution == 1)
        {
            Screen.SetResolution(1280, 720, true);
            Debug.Log(Screen.currentResolution);
        }
        if (resolution == 2)
        {
            Screen.SetResolution(800, 600, true);
        }
    }
}

