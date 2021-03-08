using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Object Data / Laser Type")]
public class LaserType : AbilityType
{
    public FloatReference projectileVelocity;
    public FloatReference projectileDelay;
}
