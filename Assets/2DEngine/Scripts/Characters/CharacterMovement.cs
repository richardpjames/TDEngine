using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/Characters/Character Movement")]

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 20f;
    protected Vector2 direction = Vector2.zero;

    // To be called from the player during fixed update
    public void Move(Rigidbody2D rb)
    {
        // Setting the velocity of the player will move them
        rb.velocity = direction.normalized * speed;
    }

    // Get the input direction
    public Vector2 GetInputDirection()
    {
        return direction;
    }

}
