using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int currentScore;
    public bool isGameActive;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    private void Start()
    {
        currentScore = 0;
        UpdateScore(currentScore);
        isGameActive = true;
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
