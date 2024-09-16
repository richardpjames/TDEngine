using Richardpjames.TDEngine.Effects;
using UnityEngine;

namespace Richardpjames.TDEngine.Weapons
{
    [AddComponentMenu("2D Engine/Weapons/Projectile")]

    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;
        [SerializeField] private int damage;
        [SerializeField] private EffectsContainer onCollisionEffects;
        private Rigidbody2D rb;
        private string ignoreTag;

        // Start is called before the first frame update
        void Start()
        {
            // Get the rigidbody
            rb = GetComponent<Rigidbody2D>();
            // Make sure no gravity applied
            rb.gravityScale = 0f;
            // Move the projectile based on our firing direction
            Transform fireDirection = transform;
            fireDirection.Rotate(0, 0, -90);
            // Setting the velocity will keep this moving
            rb.velocity = fireDirection.up * speed;
            // Destroy after the lifetime
            Destroy(gameObject, lifetime);
        }

        // Allow other items (such as weapons) to override damage
        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }

        // Ignore items with the supplied LayerMask
        public void SetExcludeLayers(LayerMask mask)
        {
            // Get the collider for the projectile
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                // Set the excluded layers as per the parameter
                collider.excludeLayers = mask;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Get any objects which can take damage
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            // If one was found
            if (target != null)
            {
                // Apply damage to the character
                target.TakeDamage(damage);
            }
            // If effects are specified
            if (onCollisionEffects != null)
            {
                // Trigger effects
                Instantiate(onCollisionEffects, transform.position, Quaternion.identity);
            }
            // Finally, desroy the projectile itself
            Destroy(gameObject);
        }
    }
}