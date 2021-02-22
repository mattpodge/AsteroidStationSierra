using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject laserBolt;
    [SerializeField] float fireRate = 0.5f;

    void Awake()
    {
        StartCoroutine(LaserFire());
    }

    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if (i == 0)
            {
                ShipRotation(touchPosition);
            }
        }

    }

    void ShipRotation(Vector3 inputPosition)
    {
        Vector3 lookDirection = transform.position - inputPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    IEnumerator LaserFire()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(laserBolt, transform.position, transform.rotation);
        }
    }
}
