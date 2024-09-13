using UnityEngine;
using UnityEngine.InputSystem;

[AddComponentMenu("2D Engine/Characters/Player/Player Movement")]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Vector2 direction = Vector2.zero;
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
        playerInputs.Player.Move.performed += OnMove;
        playerInputs.Player.Move.canceled += OnMove;

    }

    // To be called from the player during fixed update
    public void MovePlayer(Rigidbody2D rb)
    {
        // Setting the velocity of the player will move them
        rb.velocity = direction.normalized * speed;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // If the button is pressed then get the vector, on release set to zero
        if (context.performed)
        {
            direction = context.ReadValue<Vector2>();
        }
        // When the button is released
        else if(context.canceled) 
        {
            direction = Vector2.zero;
        }
    }

}
