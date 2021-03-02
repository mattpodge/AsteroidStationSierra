using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LaserType projectileData;

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * projectileData.projectSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }
}
