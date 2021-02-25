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

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public GameObject gameOverScreen;
    public GameObject powerUpsUI;


    private void Start()
    {
        currentScore = 0;
        currentWave = 0;
        isGameActive = true;

        UpdateScore(currentScore);
        UpdateWave(currentWave);
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
        gameOverScreen.SetActive(true);
        powerUpsUI.SetActive(false);
        isGameActive = false;
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
