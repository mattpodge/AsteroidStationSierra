using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody2D asteroidRb;
    [SerializeField] private ParticleSystem explosionEffect;

    private AudioSource asteroidAudio;
    [SerializeField] private AudioClip explosionSound;


    private float randomRotation;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = GetComponent<Rigidbody2D>();
        asteroidAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Vector3 target = (Vector3.zero - transform.position).normalized;
        target.x += Random.Range(-0.5f, 0.5f);
        target.y += Random.Range(-0.5f, 0.5f);
        randomRotation = Random.Range(-90.0f, 90.0f);

        float speedInc = gameManager.currentWave * 0.25f;

        asteroidRb.AddForce(target * (Random.Range(0.5f, 1.5f) + speedInc), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, randomRotation * (Random.Range(0.5f, 5.0f) * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            AudioSource.PlayClipAtPoint(explosionSound, gameObject.transform.position, 1.0f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            gameManager.UpdateScore(10);
            gameManager.asteroidsDestroyed += 1;
        }

    }
}
