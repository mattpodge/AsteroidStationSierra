using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> asteroidsPrefab;

    private Camera cam;
    private float camHeight;
    private float camWidth;

    private float rangeX;
    private float rangeY;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        rangeX = camWidth / 2;
        rangeY = camHeight / 2;

        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
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

            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
        }
    }
}
