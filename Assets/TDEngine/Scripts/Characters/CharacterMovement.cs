using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("2D Engine/Characters/Character Movement")]

    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] protected float speed = 20f;
        [SerializeField] NavMeshAgent agent;
        protected Vector2 direction = Vector2.zero;

        // Required updates for 2D NavMesh agent
        void Start()
        {
            // Required to ensure the agent doesn't rotate in 3D space
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        // Moves the character to a particular location using the nav agent
        public void MoveTo(Vector3 destination)
        {
            // Set the speed of the agent and move to the destination supplied
            agent.speed = speed;
            // Set a high acceleration so that characters come straight up to speed
            agent.acceleration = float.MaxValue;
            agent.SetDestination(destination);
        }

    }
}