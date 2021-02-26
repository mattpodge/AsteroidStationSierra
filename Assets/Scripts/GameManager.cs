using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int currentScore;
    public int asteroidsDestroyed;
    public int currentWave;
    public bool isGameActive;

    public int highScore;
    public int prevHighScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI hiScoreText;
    public GameObject gameOverScreen;
    public GameObject powerUpsUI;


    private void Start()
    {
        currentScore = 0;
        currentWave = 0;
        isGameActive = true;

        highScore = PlayerPrefs.GetInt("highScore", highScore);
        prevHighScore = highScore;

        UpdateScore(currentScore);
        UpdateWave(currentWave);
    }

    private void Update()
    {
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore.ToString("D6");
    }

    public void UpdateWave(int currentWave)
    {
        waveText.text = "Wave: " + currentWave.ToString("D3");
    }

    public void GameOver()
    {
        hiScoreText.text = "High Score: " + highScore.ToString("D6");

        if (currentScore > highScore)
        {
            highScore = currentScore;
            hiScoreText.text = "!! NEW High Score: " + highScore.ToString("D6") + " !!";
        }

        gameOverScreen.SetActive(true);
        powerUpsUI.SetActive(false);
        isGameActive = false;

        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
