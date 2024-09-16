using UnityEngine;
using UnityEngine.InputSystem;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("2D Engine/Characters/Player Movement")]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] protected float speed = 20f;
        private Vector2 direction;

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
            // Now subscribe to the correct events 
            playerInputs.Player.Move.performed += GetDirectionFromInput;
            playerInputs.Player.Move.canceled += GetDirectionFromInput;
            playerInputs.Player.Fire.performed += Fire;
            playerInputs.Player.Fire.canceled += Fire;
        }

        // Unsubscribe from the input actions when destroyed
        private void OnDestroy()
        {
            playerInputs.Player.Move.performed -= GetDirectionFromInput;
            playerInputs.Player.Move.canceled -= GetDirectionFromInput;
            playerInputs.Player.Fire.performed -= Fire;
            playerInputs.Player.Fire.canceled -= Fire;
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

        // Get the direction that has been input
        public Vector2 GetInputDirection()
        {
            return direction;
        }

        // Moves the character based on the player input
        private void FixedUpdate()
        {
            // Move using the Rigidbody
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // Setting velocity usese built in physics
            rb.velocity = direction * speed;
        }

        // Getting input for firing the weapon
        private void Fire(InputAction.CallbackContext context)
        {
            // Check whether a weapon slot exists on the character
            CharacterWeaponSlot weaponSlot = GetComponent<CharacterWeaponSlot>();
            if (weaponSlot != null)
            {
                // If so and the button is just pressed, then start firing
                if (context.performed)
                {
                    weaponSlot.SetFiring(true);

                }
                // If so and the button was just released, then stop firing
                else if (context.canceled)
                {
                    weaponSlot.SetFiring(false);
                }
            }
        }

    }
}