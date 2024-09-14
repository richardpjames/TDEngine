using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Weapons/Projectile Weapon")]

public class ProjectileWeapon : Weapon
{
    [SerializeField] protected Projectile projectile;
    [SerializeField] protected Transform firePoint;
    void Update()
    {
        // If the triggere for firing is set, and the cooldown has passed
        if(firing && Time.time >= nextFireTime)
        {
            // Instantiate the projectile, which will deal with its own movement
            Projectile spawnedProjectile = Instantiate(projectile, firePoint.position, transform.rotation * Quaternion.Euler(new Vector3(0,0,90)));
            // If the weapon is configured to override damage
            if(overrideDamage)
            {
                spawnedProjectile.SetDamage(damage);
            }
            // Update the cooldown time
            nextFireTime = Time.time + cooldown;
        }
    }
}
