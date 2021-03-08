using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroidRb;

    public IntVariable maxAsteroidCount;

    public AsteroidsData asteroidsData;
    private int scoreValue;
    private bool targetsPlayer;
    private float targetAccuracy;
    private float rotationRange;
    private float minVelocity;
    private float maxVelocity;
    private ParticleSystem explosionEffect;

    public AsteroidsData subAsteroids;

    private Vector3 asteroidDirection;
    private float randomAsteroidRotation;
    private float randomAsteroidVelocity;

    private Vector3 target = Vector3.zero;

    public GameEvent asteroidShotEvent;

    void Start()
    {
        asteroidRb = GetComponent<Rigidbody2D>();

        scoreValue = asteroidsData.scoreValue;
        targetsPlayer = asteroidsData.targetsPlayer;
        targetAccuracy = asteroidsData.targetAccuracy;
        rotationRange = asteroidsData.rotationRange;
        minVelocity = asteroidsData.minVelocity;
        maxVelocity = asteroidsData.maxVelocity;
        explosionEffect = asteroidsData.explosionEffect;

        // Increase target accuracy every wave
        targetAccuracy -= asteroidsData.currentWave.Value * 0.25f;

        // Increase potential velocity every wave
        minVelocity += asteroidsData.currentWave.Value * 0.25f;

        // Set our asteroids off at random rotation speeds/directions and velocity
        randomAsteroidRotation = Random.Range(-rotationRange, rotationRange);
        randomAsteroidVelocity = Random.Range(minVelocity, maxVelocity);

        if (targetsPlayer)
        {
            // Decrease the accuracy of our asteroids within our error window ranges
            target.x += Random.Range(-targetAccuracy, targetAccuracy);
            target.y += Random.Range(-targetAccuracy, targetAccuracy);

        } else
        {
            target = new Vector3(Random.Range(-CameraSize.width, CameraSize.width), Random.Range(-CameraSize.height, CameraSize.height), 0);
        }

        // Set the point where our asteroid is aiming for
        asteroidDirection = (target - transform.position).normalized;


        // Give our asteroid a push on start
        asteroidRb.AddForce(asteroidDirection * randomAsteroidVelocity, ForceMode2D.Impulse);
    }
    void FixedUpdate()
    {
        // Spin our asteroids as they hurtle through space
        transform.Rotate(Vector3.forward * randomAsteroidRotation * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);

            if(!targetsPlayer)
            {
                maxAsteroidCount.ApplyChange(-1);
            }
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            asteroidShotEvent.sentInt = scoreValue;
            asteroidShotEvent.Raise();

            if (targetsPlayer)
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = Random.Range(0, subAsteroids.asteroids.Length);
                    Vector3 spawnPos = transform.position + Vector3.zero;

                    if (i % 2 == 0)
                    {
                        spawnPos.x += -0.25f;
                        spawnPos.y += 0.25f;
                    } else
                    {
                        spawnPos.x += 0.25f;
                        spawnPos.y += -0.25f;
                    }

                    Instantiate(subAsteroids.asteroids[index], spawnPos, transform.rotation);
                }
                maxAsteroidCount.ApplyChange(1);
            }
        }
    }
}
