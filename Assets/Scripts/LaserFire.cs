using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{

    [SerializeField] float laserVelocity = 10.0f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * laserVelocity * Time.deltaTime);
    }
}
