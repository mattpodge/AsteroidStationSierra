using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] float laserVelocity = 10.0f;
    [SerializeField] private ParticleSystem explosionEffect;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * laserVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collison.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(10);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }

}
