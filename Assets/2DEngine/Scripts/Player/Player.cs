using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Characters/Player/Player Controller")]

public class Player : Character
{
    // Start is called before the first frame update
    new void Start()
    {
        // Call the general character start method
        base.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If there is a movement component
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            // Then use this to move the player rigidbody
            playerMovement.MovePlayer(rb);
        }
    }
}
