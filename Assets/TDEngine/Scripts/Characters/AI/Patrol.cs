using Richardpjames.TDEngine.Characters;
using UnityEngine;

namespace Richardpjames.TDEngine.Characters.AI
{
    [AddComponentMenu("2D Engine/Characters/AI Actions/Patrol")]

    public class Patrol : CharacterAIAction, IAction
    {
        // At what distance be we consider we've got to the point
        [SerializeField] private float distance;
        [SerializeField] private Transform[] patrolRoute;
        private int currentPatrolPoint = 0;
        public override void Perform()
        {
            // Get the character movement component and return if not present
            CharacterMovement characterMovement = GetComponent<CharacterMovement>();
            if (characterMovement == null) return;
            // If there are no patrol points then exit
            if (patrolRoute.Length == 0) return;
            // If we are within distance of the next patrol point, then move to the next
            if (Vector2.Distance(patrolRoute[currentPatrolPoint].position, transform.position) < distance)
            {
                // Increment to the next point on the patrol path
                currentPatrolPoint++;
                // Loop back around if we reach the end of the list
                if (currentPatrolPoint >= patrolRoute.Length)
                {
                    currentPatrolPoint = 0;
                }
            }
            // Move towards the next patrol point
            characterMovement.MoveTo(patrolRoute[currentPatrolPoint].position);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, distance);
            Gizmos.color = Color.green;
            // Daw a cube at each of the patrol points
            foreach (Transform patrolPoint in patrolRoute)
            {
                Gizmos.DrawSphere(patrolPoint.position, 0.25f);
            }
        }
    }
}