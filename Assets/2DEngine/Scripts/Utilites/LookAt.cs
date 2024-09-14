using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Utilities/Look At")]

public class LookAt : MonoBehaviour
{
    // Check what we are looking at (the mouse or object) and if we need to rotate the object further
    private enum LookType { Player, Mouse };
    [SerializeField] private LookType lookType;
    [SerializeField] private float additionalRotation = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lookType == LookType.Mouse)
        {
            // Rotate the transform to point towards the mouse
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetAngleToMouse()));
        }
        else if(lookType == LookType.Player)
        {
            // Rotate the transform to point towards the object
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetAngleToPlayer()));
        }
        // Apply additional rotation
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -additionalRotation));
    }
    private float GetAngleToPlayer()
    {
        // Find the player in the scene and get the character component
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (player == null)
        {
            return 0;
        }
        // Get the position of the player
        Vector3 playerPosition = player.transform.position;
        // Subtract from the object position to account for direction
        playerPosition.x -= transform.position.x;
        playerPosition.y -= transform.position.y;
        // Apply the correct rotation
        return Mathf.Atan2(playerPosition.y, playerPosition.x) * Mathf.Rad2Deg;
    }
    private float GetAngleToMouse()
    {
        // Get the position of the mouse
        Vector3 mousePosition = Input.mousePosition;
        // Get the position of the spaceship
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        // Subtract from the mouse position to account for direction
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;
        // Apply the correct rotation
        return Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
    }
}
