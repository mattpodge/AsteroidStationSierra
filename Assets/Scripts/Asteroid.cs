using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroid;

    private Vector3 asteroidDirection;
    private float randomAsteroidRotation;
    private float randomAsteroidVelocity;

    private Vector3 target = Vector3.zero;
    [Range(0f, 5f)]
    public float errorWindow = 0;

    public UnityEvent AsteroidShot;

    void Start()
    {
        asteroid = GetComponent<Rigidbody2D>();

        // Set our asteroids off at random rotation speeds/directions and velocity
        randomAsteroidRotation = Random.Range(-180f, 180f);
        randomAsteroidVelocity = Random.Range(0.5f, 4f);

        // Decrease the accuracy of our asteroids within our error window ranges
        target.x += Random.Range(-errorWindow, errorWindow);
        target.y += Random.Range(-errorWindow, errorWindow);

        // Set the point where our asteroid is aiming for
        asteroidDirection = (target - transform.position).normalized;

        // Give our asteroid a push on start
        asteroid.AddForce(asteroidDirection * randomAsteroidVelocity, ForceMode2D.Impulse);
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
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            AsteroidShot.Invoke();

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
