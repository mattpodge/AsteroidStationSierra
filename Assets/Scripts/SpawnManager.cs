using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{

    public GameManager gm;

    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> asteroidsPrefab;

    private Camera cam;
    private float camHeight;
    private float camWidth;

    private float rangeX;
    private float rangeY;

    public int asteroidCount;
    public int asteroidsActive;
    public int nextWave;
    private int minWaveTarget;
    private int maxWaveTarget;
    public int maxAsteroids;

    private float minDelay;
    private float maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        rangeX = camWidth / 2;
        rangeY = camHeight / 2;

        asteroidCount = 0;
        nextWave = gm.currentWave + 1;
        minWaveTarget = 0;
        maxWaveTarget = nextWave * 5;
        maxAsteroids = 5;

        minDelay = 1.0f;
        maxDelay = 3.0f;

        StartCoroutine(SpawnAsteroids());
    }

    private void Update()
    {

        asteroidsActive = GameObject.FindGameObjectsWithTag("Asteroid").Length;

        int upgradeNum = minWaveTarget + maxWaveTarget;

        if (gm.asteroidsDestroyed == upgradeNum)
        {
            gm.currentWave += 1;
            nextWave += 1;
            minWaveTarget = upgradeNum;
            maxWaveTarget = nextWave * 5;
            maxAsteroids += 5;

            minDelay -= (gm.currentWave * 0.1f);
            maxDelay -= (gm.currentWave * 0.2f);

            gm.UpdateWave(gm.currentWave);
        }
    }


    IEnumerator SpawnAsteroids()
    {
        
        while (asteroidsActive < maxAsteroids)
        {
            Vector3 spawnPosition;
            int i = Random.Range(0, spawnPoints.Count);
            int asteroid = Random.Range(0, asteroidsPrefab.Count);

            if (spawnPoints[i].CompareTag("SpawnManY"))
            {
                spawnPosition = new Vector3(spawnPoints[i].transform.position.x, Random.Range(-rangeY, rangeY), 0.0f);
                Instantiate(asteroidsPrefab[asteroid], spawnPosition, transform.rotation);
            }
            else if (spawnPoints[i].CompareTag("SpawnManX"))
            {
                spawnPosition = new Vector3(Random.Range(-rangeX, rangeX), spawnPoints[i].transform.position.y, 0.0f);
                Instantiate(asteroidsPrefab[asteroid], spawnPosition, transform.rotation);
            }

            asteroidCount += 1;
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }
}
