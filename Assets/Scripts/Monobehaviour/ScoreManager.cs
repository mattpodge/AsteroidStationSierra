using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public IntVariable highScore;
    public IntVariable prevHighScore;
    public IntVariable currentScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        currentScore.SetValue(0);

        highScore.SetValue(PlayerPrefs.GetInt("highScore", highScore.Value));
        prevHighScore.SetValue(highScore);
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore.ApplyChange(scoreToAdd);
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.Value.ToString("D6");
        }
    }

    public void UpdateHighScore()
    {

        highScoreText.text = "High Score: " + highScore.Value.ToString("D6");

        if (currentScore.Value > highScore.Value)
        {
            highScore.SetValue(currentScore.Value);
            highScoreText.text = "!!NEW!! High Score: " + highScore.Value.ToString("D6") + " !!NEW!!";
        }

        PlayerPrefs.SetInt("highScore", highScore.Value);
        PlayerPrefs.Save();
    }
}
