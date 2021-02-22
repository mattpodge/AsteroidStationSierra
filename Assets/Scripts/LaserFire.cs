using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{

    [SerializeField] float laserVelocity = 10.0f;
    [SerializeField] private ParticleSystem explosionEffect;

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
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }

}
