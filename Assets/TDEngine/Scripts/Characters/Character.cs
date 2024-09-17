using richardpjames.com.TDEngine.Effects;
using System;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("TD Engine/Characters/Character Controller")]

    public class Character : MonoBehaviour
    {
        // For special effects on spawning
        [SerializeField] private EffectsContainer spawnEffects;
        // Rigidbody is needed for movement etc.
        protected Rigidbody2D rb;
        protected Vector2 inputDirection;
        protected void Start()
        {
            // Grab the rigidbody and set character settings
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                throw new Exception("Characters must have a RigidBody 2D");
            }
            else
            {
                // Automatically stop characters from rotating on the Z Axis
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                // For top down games we want to stop any gravity as well
                rb.gravityScale = 0f;
            }
            // If there are any effects specified for spawning
            if (spawnEffects != null)
            {
                Instantiate(spawnEffects, transform.position, Quaternion.identity);
            }
        }

        public void Remove()
        {
            Destroy(gameObject);
        }
    }
}