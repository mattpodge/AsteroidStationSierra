using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LaserType : ScriptableObject
{
    public GameObject projectile;
    public FloatReference projectSpeed;
    public FloatReference fireRate;
}
