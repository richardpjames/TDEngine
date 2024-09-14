using UnityEngine;
using UnityEngine.InputSystem;

[AddComponentMenu("2D Engine/Characters/Player Movement")]

public class PlayerMovement : CharacterMovement
{
    // Requires inputs from the player
    private PlayerInputs playerInputs;

    public void Awake()
    {
        // Initialise our player inputs
        playerInputs = new PlayerInputs();
    }

    // We must enable the inputs on enabling the component
    private void OnEnable()
    {
        playerInputs.Enable();
        // Now subscribe to the correct events (as the input belongs to the object no need to unsubscribe)
        playerInputs.Player.Move.performed += GetDirectionFromInput;
        playerInputs.Player.Move.canceled += GetDirectionFromInput;

    }

    private void GetDirectionFromInput(InputAction.CallbackContext context)
    {
        // If the button is pressed then get the vector, on release set to zero
        if (context.performed)
        {
            direction = context.ReadValue<Vector2>();
        }
        // When the button is released
        else if (context.canceled)
        {
            direction = Vector2.zero;
        }
    }

}
