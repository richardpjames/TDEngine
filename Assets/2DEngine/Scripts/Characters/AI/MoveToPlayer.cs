using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[AddComponentMenu("2D Engine/Characters/AI Actions/Move to Player")]

public class MoveToPlayer : CharacterAIAction, IAction
{
    // At what distance be we consider we've got to the player
    [SerializeField] private float distance;
    public override void Perform()
    {
        // Get the character movement component and return if not present
        CharacterMovement characterMovement = GetComponent<CharacterMovement>();
        if (characterMovement == null) return;
        // Get the player and return if not present
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (player == null) return;
        // If further than the distance then move towards the player, otherwise hold still
        if (Vector2.Distance(characterMovement.transform.position, player.transform.position) > distance)
        {
            characterMovement.MoveTo(player.transform.position);
        }
        // Hold still if we are close enough to the player
        else
        {
            characterMovement.MoveTo(characterMovement.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
