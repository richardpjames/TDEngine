using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("TD Engine/Characters/Character Animator")]
    public class CharacterAnimator : MonoBehaviour
    {
        // The animator component for the character
        [SerializeField] protected Animator animator;
        [SerializeField] protected Transform spriteParent;

        // Determine which animations to run
        void Update()
        {
            // Required for checking movement for AI controlled characters
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            // Required for checking movement direction (check if running)
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            // Reset all animator variables
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
            // Determine which to set to true based on state
            if(navMeshAgent != null && navMeshAgent.velocity != Vector3.zero)
            {
                animator.SetBool("Running", true);
            }
            else if (playerMovement != null && playerMovement.GetInputDirection() != Vector2.zero)
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Idle", true);
            }
            // Flip sprite based on direction of travel (if there is one specified)
            if (playerMovement != null && spriteParent != null)
            {
                // Check the x direction that we are moving in
                float horizontalMovement = playerMovement.GetInputDirection().x;
                // Scale on the x axis to give the effect of flipping the sprite
                if (horizontalMovement < 0)
                {
                    spriteParent.localScale = new Vector3(-1f, 1f, 1f);
                }
                else if (horizontalMovement > 0)
                {
                    spriteParent.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }
    }
}