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

    [SerializeField] AudioClip themeMusic;

    [SerializeField] GameObject PauseCanvas;

    bool isMusicOn;
    bool isMenuActive = false;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
        PauseCanvas.SetActive(false);
    }

    private void Update()
    {
        DebugRestartLevel();
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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

    private void MusicPlayer()
    {
        audioSource.PlayOneShot(themeMusic);
    }

    private void DebugRestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }

    public void TurnMusicOnOff()
    {
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            audioSource.volume = 1f;
        }
        else
        {

            audioSource.volume = 0f;
        }
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            if (isMenuActive)
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
}
