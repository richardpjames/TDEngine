using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected bool firing = false;
    protected float nextFireTime;
    // Begin and stop firing (allows for holding controls)
    public virtual void SetFiring(bool newFiringValue)
    {
        firing = newFiringValue;
    }

}
