using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/Characters/Character Animator")]
public class CharacterAnimator : MonoBehaviour
{
    // The animator component for the character
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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