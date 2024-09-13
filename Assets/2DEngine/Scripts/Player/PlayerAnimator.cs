using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/Player/Player Animator")]
public class PlayerAnimator : CharacterAnimator
{
    // The animator component for the player
    [SerializeField] private Animator animator;

    // Determine which animations to run
    void Update()
    {
        // Required for checking movement direction (check if running)
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        // Reset all animator variables
        animator.SetBool("Running", false);
        animator.SetBool("Idle", false);
        // Determine which to set to true based on state
        if (playerMovement != null && playerMovement.GetInputDirection() != Vector2.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }
}
