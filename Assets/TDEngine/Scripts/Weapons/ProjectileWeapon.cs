using UnityEngine;

namespace Richardpjames.TDEngine.Weapons
{
    [AddComponentMenu("2D Engine/Weapons/Projectile Weapon")]

    public class ProjectileWeapon : Weapon
    {
        [SerializeField] protected Projectile projectile;
        [SerializeField] protected Transform firePoint;
        [SerializeField] protected GameObject fireEffects;
        void Update()
        {
            // If the triggere for firing is set, and the cooldown has passed
            if (firing && Time.time >= nextFireTime)
            {
                // If any effects are specified
                if (fireEffects != null)
                {
                    // Instantiate the effects at the fire point
                    Instantiate(fireEffects, firePoint.position, firePoint.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                // Instantiate the projectile, which will deal with its own movement
                Projectile spawnedProjectile = Instantiate(projectile, firePoint.position, firePoint.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 90)));
                // If the weapon is configured to override damage
                if (overrideDamage)
                {
                    spawnedProjectile.SetDamage(damage);
                }
                // Pass through the layers not affected by the weapon
                spawnedProjectile.SetExcludeLayers(excludeLayers);
                // Update the cooldown time
                nextFireTime = Time.time + cooldown;
            }
        }
    }
}