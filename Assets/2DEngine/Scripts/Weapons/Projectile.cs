using UnityEngine;
using UnityEngine.VFX;

[AddComponentMenu("2D Engine/Weapons/Projectile")]

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    [SerializeField] private int damage;
    [SerializeField] private EffectsContainer onCollisionEffects;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody
        rb = GetComponent<Rigidbody2D>();
        // Move the projectile based on our firing direction
        Transform fireDirection = transform;
        fireDirection.Rotate(0, 0, -90);
        // Setting the velocity will keep this moving
        rb.velocity = fireDirection.up * speed;
        // Destroy after the lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get any objects which can take damage
        CharacterHealth health = collision.gameObject.GetComponent<CharacterHealth>();
        // If one was found
        if (health != null)
        {
            // Apply damage to the character
            health.TakeDamage(damage);
        }
        // If effects are specified
        if (onCollisionEffects != null)
        {
            // Trigger effects
            onCollisionEffects.PlayAll(transform.position);
        }
        // Finally, desroy the projectile itself
        Destroy(gameObject);
    }
}