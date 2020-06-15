using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject OptionsCanvas;

    bool isPauseActive;

    private void Awake()
    {
        int numScene = FindObjectsOfType<GameSession>().Length;
        if (numScene > 1)
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
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        PauseGame();
    }


    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
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
        

    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
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



}

