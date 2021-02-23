using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{

    private Rigidbody2D asteroidRb;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRb = gameObject.GetComponent<Rigidbody2D>();

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

}
