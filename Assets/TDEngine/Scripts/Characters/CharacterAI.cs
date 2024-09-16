using richardpjames.com.TDEngine.Characters.AI;
using System;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("2D Engine/Characters/Character AI")]

    public class CharacterAI : MonoBehaviour
    {
        [SerializeField] private float evaluationCooldown = 1;
        [SerializeField] private CharacterAIConfiguration[] configurations;
        private float nextEvaluationTime;
        // Those actions which are being performed each frame
        private CharacterAIAction[] activeActions = new CharacterAIAction[0];

        void Update()
        {
            // Check that we are due to reevaluate
            if (Time.time > nextEvaluationTime)
            {
                // Loop through all pairs of conditions and actions
                foreach (CharacterAIConfiguration configuration in configurations)
                {
                    bool allTrue = true;
                    foreach (CharacterAICondition condition in configuration.conditions)
                    {
                        if (condition != null)
                        {
                            // This will update to false if any conditions are not met
                            allTrue = allTrue && condition.Evaluate();
                        }
                    }
                    // If all of the conditions are met then update active actions
                    if (allTrue)
                    {
                        activeActions = configuration.actions;
                        // Break out of the loop
                        break;
                    }
                }
                // Reset the cooldown timer
                nextEvaluationTime = Time.time + evaluationCooldown;
            }
            // Perform all of the actions specified on every frame (each actions perform is the equivalent of Update())
            foreach (CharacterAIAction action in activeActions)
            {
                if (action != null)
                {
                    action.Perform();
                }
            }
        }

        [Serializable]
        struct CharacterAIConfiguration
        {
            public CharacterAICondition[] conditions;
            public CharacterAIAction[] actions;
        }
    }
}