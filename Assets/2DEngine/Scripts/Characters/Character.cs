using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/Characters/Character Controller")]

public class Character : MonoBehaviour
{
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
    }
    private void FixedUpdate()
    {
        // If there is a movement component
        CharacterMovement characterMovement = GetComponent<CharacterMovement>();
        if (characterMovement != null)
        {
            // Then use this to move the player rigidbody
            characterMovement.Move(rb);
        }
    }

}
