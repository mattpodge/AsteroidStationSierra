using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody2D asteroidRb;
    [SerializeField] private ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Vector3 target = (Vector3.zero - transform.position).normalized;
        target.x += Random.Range(-0.5f, 0.5f);
        target.y += Random.Range(-0.5f, 0.5f);

        asteroidRb.AddForce(target * Random.Range(1, 4), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 90.0f * Random.Range(0.5f, 5.0f) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(10);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

    }
}
