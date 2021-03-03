using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public IntReference currentWave, waveIncrement;
    public float minSpawnDelay, maxSpawnDelay;

    private readonly float minSpawnDelayLimit = 0.125f;
    private readonly int maxAsteroidsCountLimit = 40;

    public List<GameObject> lgAsteroids;

    private int asteroidActiveCount, maxAsteroidCount;
    private float xSpawnRange, ySpawnRange;
    private GameObject[] sensors, spawnPoints;


    void Start()
    {
        // Set our spawn ranges based on camera/screen size
        xSpawnRange = CameraSize.width * 1.25f;
        ySpawnRange = CameraSize.height * 1.25f;

        SpawnPointTransforms();
        SensorTransforms();
        StartCoroutine(SpawnAsteroids());
        IncreaseActiveSpawns();
    }

    private void Update()
    {
        // Count how many asteroids are currently active
        asteroidActiveCount = GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }

    public void IncreaseActiveSpawns()
    {
        if (maxAsteroidCount != maxAsteroidsCountLimit)
        {
            // Increase how many active spawns are allowed
            maxAsteroidCount += waveIncrement.Value;
        }

        if (minSpawnDelay > minSpawnDelayLimit)
        {
            // Shorten the delay window between spawns
            minSpawnDelay *= 0.875f;
            maxSpawnDelay *= 0.875f;
        }
    }


    IEnumerator SpawnAsteroids()
    {
        while(true)
        {
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            float randomXPos = Random.Range(-xSpawnRange, xSpawnRange);
            float randomYPos = Random.Range(-ySpawnRange, ySpawnRange);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            int asteroidIndex = Random.Range(0, lgAsteroids.Count);


            // Spawn position is dependant on which spawn point is instantiating the asteroid
            Vector2 spawnPos = (
                spawnPoints[spawnIndex].transform.position.y == 0f ? 
                new Vector2(spawnPoints[spawnIndex].transform.position.x, randomYPos) : 
                new Vector2(randomXPos, spawnPoints[spawnIndex].transform.position.y)
            );
            
            // Some randomness to when asteroids spawn
            yield return new WaitForSeconds(spawnDelay);

            // As long as we haven't hit our max asteroid count, spawn an asteroid
            if (asteroidActiveCount < maxAsteroidCount)
            {
                Instantiate(lgAsteroids[asteroidIndex], spawnPos, lgAsteroids[asteroidIndex].transform.rotation);
            }
        }
    }

    void SpawnPointTransforms()
    {
        // Find our spawnpoints
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        // Position spawn points relative to camera/screem size
        foreach (GameObject spawnPoint in spawnPoints)
        {
            switch (spawnPoint.name)
            {
                case "SpawnPointTop":
                    spawnPoint.transform.position = new Vector2(0f, CameraSize.height + 1f);
                    break;
                case "SpawnPointRight":
                    spawnPoint.transform.position = new Vector2(CameraSize.width + 1f, 0f);
                    break;
                case "SpawnPointLeft":
                    spawnPoint.transform.position = new Vector2(-(CameraSize.width + 1f), 0f);
                    break;
                default:
                    break;
            }
        }
    }

    void SensorTransforms()
    {
        // Find our sensors
        sensors = GameObject.FindGameObjectsWithTag("Sensor");

        // Position & resize sensors relative to camera/screen size
        foreach (GameObject sensor in sensors)
        {
            switch (sensor.name)
            {
                case "SensorTop":
                    sensor.transform.position = new Vector2(0f, CameraSize.height + 2.5f);
                    sensor.transform.localScale = new Vector2(CameraSize.width * 4, 1f);
                    break;
                case "SensorRight":
                    sensor.transform.position = new Vector2(CameraSize.width + 2.5f, 0f);
                    sensor.transform.localScale = new Vector2(1f, CameraSize.height * 4);
                    break;
                case "SensorBottom":
                    sensor.transform.position = new Vector2(0f, -(CameraSize.height + 2.5f));
                    sensor.transform.localScale = new Vector2(CameraSize.width * 4, 1f);
                    break;
                case "SensorLeft":
                    sensor.transform.position = new Vector2(-(CameraSize.width + 2.5f), 0f);
                    sensor.transform.localScale = new Vector2(1f, CameraSize.height * 4);
                    break;
                default:
                    break;
            }
        }
    }
}
