using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public IntVariable currentScore;

    public void UpdateScore(int scoreToAdd)
    {
        currentScore.ApplyChange(scoreToAdd);
    }
}
