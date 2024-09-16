using richardpjames.com.TDEngine.Characters;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters.AI
{
    [AddComponentMenu("2D Engine/Characters/AI Conditions/Player Less Than Distance")]

    public class PlayerLessThanDistance : CharacterAICondition, ICondition
    {
        [SerializeField] private float distance;
        public override bool Evaluate()
        {
            // Find the player in the scene
            Character player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Character>();
            // If there is no player then return false
            if (player == null) return false;
            // If the character is within distance then return true
            if (Vector2.Distance(transform.position, player.transform.position) < distance) return true;
            // Otherwise return false
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, distance);
        }
    }
}