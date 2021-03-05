using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public IntVariable currentScore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        currentScore.SetValue(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore.ApplyChange(scoreToAdd);
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.Value.ToString("D6");
        }
    }
}
