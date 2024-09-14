using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    // Required updates for 2D NavMesh agent
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get our player and follow
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
