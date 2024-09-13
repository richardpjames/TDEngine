using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
