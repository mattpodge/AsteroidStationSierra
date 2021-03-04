using UnityEngine;
using TMPro;

public class UICurrentScore : MonoBehaviour
{
    public IntReference currentScore;
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore.Value.ToString("D6");
    }
}
