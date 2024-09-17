using UnityEngine;
using UnityEngine.InputSystem;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("TD Engine/Characters/Player Interaction")]
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float interactionRadius;
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
            playerInputs.Player.Interact.performed += Interact;
            playerInputs.Player.Interact.canceled += Interact;
        }

        // Unsubscribe from the input actions when destroyed
        private void OnDestroy()
        {
            playerInputs.Player.Interact.performed -= Interact;
            playerInputs.Player.Interact.canceled -= Interact;
        }

        private void Interact(InputAction.CallbackContext context)
        {
            // Only trigger when the action is performed (not cancelled)
            if (context.performed)
            {
                // Get everything that collides within the interaction radius of the player
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
                // Get the character component for the interaction (returning if not present)
                Character character = GetComponent<Character>();
                if (character == null) return;
                // Loop through the colliders and interact where we can
                foreach (Collider2D collider in colliders)
                {
                    // Get any objects which implement the interactable interface
                    IInteractable interactable = collider.GetComponent<IInteractable>();
                    // If present, then interact, passing over the player
                    if (interactable != null)
                    {
                        interactable.Interact(character);
                    }
                }
            }

        }

        private void OnDrawGizmosSelected()
        {
            // Draw the interaction radius in yellow
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
}