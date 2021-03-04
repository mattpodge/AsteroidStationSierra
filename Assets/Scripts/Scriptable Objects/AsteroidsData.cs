using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Spawns/Asteroids")]
public class AsteroidsData : ScriptableObject
{
    public int scoreValue;
    public float targetAccuracy;
    public float rotationRange;
    [Range(0.25f, 1.5f)]
    public float minVelocity;
    [Range(0.5f, 3)]
    public float maxVelocity;

    public IntReference currentWave;

    public GameObject[] asteroids;
}
