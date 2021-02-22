using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    private Rigidbody2D asteroidRb;
    private GameObject player;
    [SerializeField] private ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        Vector3 target = (player.transform.position - transform.position).normalized;
        target.x += Random.Range(-0.5f, 0.5f);
        target.y += Random.Range(-0.5f, 0.5f);

        asteroidRb.AddForce(target * Random.Range(1, 4), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Random.Range(-90.0f, 90.0f) * 1f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            // destory player & game over
        }
    }
}
