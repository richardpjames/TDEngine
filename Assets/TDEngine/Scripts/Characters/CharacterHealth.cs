using richardpjames.com.TDEngine.Effects;
using richardpjames.com.TDEngine.Managers;
using System;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("TD Engine/Characters/Character Health")]

    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        // The characters maximum health and whether their death ends the game
        [SerializeField] protected int maxHealth;
        [SerializeField] protected EffectsContainer deathEffects;
        protected int currentHealth;
        protected bool isQuitting = false;
        private void Awake()
        {
            // Connect to the respawn component if it is present
            CharacterRespawn respawn = GetComponent<CharacterRespawn>();
            if (respawn != null)
            {
                respawn.OnRespawn += Reset;
            }
        }

         private void Start()
        {
            // Initialise current health on spawn
            currentHealth = maxHealth;
        }

        // Reset the characters health to the maximum
        public void Reset()
        {
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            // If the character is already dead then nothing furthe rneeded
            if (IsDead()) return;
            // Otherwise reduce the health of the character
            currentHealth = currentHealth - damage;
            currentHealth = Math.Max(currentHealth, 0);
            // Check if the current health is less than zero (leading to death)
            if (currentHealth <= 0)
            {
                // Drop any loot (if component present)
                CharacterDrops drops = GetComponent<CharacterDrops>();
                drops?.Drop();
                // If this is the player then respawn
                if (tag == "Player")
                {
                    LevelManager.Instance.ReSpawn();
                }
                else
                {
                    // Check whether the character is able to respawn
                    CharacterRespawn respawn = GetComponent<CharacterRespawn>();
                    if (respawn != null)
                    {
                        respawn.ReSpawn();
                    }
                    else { 
                    // Otherwise destroy the object
                    Destroy(gameObject);
                    }
                }
            }
        }

        // Determine if the player is dead based on health
        public bool IsDead()
        {
            // If health has reached zero then the character is dead
            return currentHealth <= 0;
        }

        private void OnDestroy()
        {
            // Disconnect from the respawn component if it is present
            CharacterRespawn respawn = GetComponent<CharacterRespawn>();
            if (respawn != null)
            {
                respawn.OnRespawn -= Reset;
            }
            // Check that the application is not closing and that effects are specified
            if (!isQuitting && deathEffects != null)
            {
                // Instantiate the effects prefab
                Instantiate(deathEffects, transform.position, Quaternion.identity);
            }
        }

        // Need to check for application quitting if utilising OnDestroy to create new objects
        private void OnApplicationQuit()
        {
            isQuitting = true;
        }
    }
}