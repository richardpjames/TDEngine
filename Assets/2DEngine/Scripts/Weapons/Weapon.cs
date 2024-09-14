using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[AddComponentMenu("")]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    [SerializeField] protected bool overrideDamage;
    [SerializeField] protected int damage;
    protected LayerMask excludeLayers;

    protected bool firing = false;
    protected float nextFireTime;
    // Begin and stop firing (allows for holding controls)
    public virtual void SetFiring(bool newFiringValue)
    {
        firing = newFiringValue;
    }

    // Set any layers to be ignored by the weapon
    public virtual void SetExcludeLayers(LayerMask mask)
    {
        excludeLayers = mask;
    }

}
