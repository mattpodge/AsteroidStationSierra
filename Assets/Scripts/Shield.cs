using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(Vector3.forward, 360.0f * 0.5f * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            AbilitiesManager.isShieldActive = false;
        }
    }
}
