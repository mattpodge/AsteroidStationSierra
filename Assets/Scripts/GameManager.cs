using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool resetScore;
    public FloatVariable currentScore;
    public IntVariable currentWave;
    public IntVariable asteroidsDestroyed;

    private int currentScoreTarget;
    private int nextScoreTarget;

    public UnityEvent NewWave;


    void Start()
    {
        if (resetScore)
        {
            currentScore.SetValue(0);
            currentWave.SetValue(0);
            asteroidsDestroyed.SetValue(0);
        }

        currentScoreTarget = currentWave.Value * 5;
        nextScoreTarget = (currentWave.Value + 1) * 5;
    }

    void Update()
    {
    }

    public void UpdateWave()
    {
        int upgradeTarget = currentScoreTarget + nextScoreTarget;

        if (asteroidsDestroyed.Value == upgradeTarget)
        {
            Debug.Log("Next Wave");
            currentWave.ApplyChange(1);
            currentScoreTarget = upgradeTarget;
            nextScoreTarget = (currentWave.Value + 1) * 5;
            NewWave.Invoke();
        }
    }

    public void UpdateScore()
    {
        currentScore.ApplyChange(5);
    }
}
