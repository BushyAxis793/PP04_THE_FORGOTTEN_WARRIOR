using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
        LoadNextScene();
    }
    public int GetCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        return currentScene;
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

        SceneManager.LoadScene(GetCurrentScene());

        score = 0;
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }
    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void PauseGame()
    {

        if (GetCurrentScene() == 0)
        {
            return;
        }

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
        PauseCanvas.SetActive(false);
    }
    //Debug
    private void LoadNextScene()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(GetCurrentScene() + 1);
        }
    }
}

