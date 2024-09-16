using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/Character Health")]

public class CharacterHealth : MonoBehaviour, IDamageable
{
    // The characters maximum health and whether their death ends the game
    [SerializeField] protected int maxHealth;
    [SerializeField] protected EffectsContainer deathEffects;
    protected int currentHealth;
    protected bool isQuitting = false;

    private void Start()
    {
        // Initialise current health on spawn
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
            // If this is the player then respawn
            if (tag == "Player")
            {
                LevelManager.Instance.ReSpawn();
            }
            else
            {
                // Otherwise destroy the object
                Destroy(gameObject);
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
        // Check that the application is not closing and that effects are specified
        if(!isQuitting && deathEffects != null)
        {
            deathEffects.PlayAll(transform.position);
        }
    }

    // Need to check for application quitting if utilising OnDestroy to create new objects
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
