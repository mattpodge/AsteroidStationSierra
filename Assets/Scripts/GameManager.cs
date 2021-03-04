using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public IntVariable currentScore;
    public IntVariable asteroidsDestroyed;

    void Start()
    {
        currentScore.SetValue(0);
        asteroidsDestroyed.SetValue(0);
    }
}
