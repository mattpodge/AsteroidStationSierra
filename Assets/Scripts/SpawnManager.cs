using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> lgAsteroids;
    public List<GameObject> spawnPoints;

    public int currentWave = 1;

    private int asteroidActiveCount;
    public int maxAsteroidCount = 5;

    private float xMin = -10;
    private float xMax = 10;

    private float yMin = -10;
    private float yMax = 10;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    private void Update()
    {
        asteroidActiveCount = GameObject.FindGameObjectsWithTag("Asteroid").Length;

        Debug.Log("Active Asteroids: " + asteroidActiveCount + ", Max Asteroids: " + maxAsteroidCount);
    }

    IEnumerator SpawnAsteroids()
    {
        Vector2 spawnPos;

        while(true)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            float randomXPos = Random.Range(xMin, xMax);
            float randomYPos = Random.Range(yMin, yMax);
            int asteroidIndex = Random.Range(0, lgAsteroids.Count);

            spawnPos = (spawnPoints[spawnIndex].CompareTag("SpawnPtVert") ? new Vector3(spawnPoints[spawnIndex].transform.position.x, randomYPos, 0f) : new Vector3(randomXPos, spawnPoints[spawnIndex].transform.position.y, 0f));
            
            if (asteroidActiveCount < maxAsteroidCount)
            {
                Instantiate(lgAsteroids[asteroidIndex], spawnPos, lgAsteroids[asteroidIndex].transform.rotation);
            }

            yield return new WaitForSeconds(1.0f);
        }

    }
}
