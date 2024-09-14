using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Get our player and follow
        Character player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        if (player != null)
        {
            GetComponent<CharacterMovement>().MoveTo(player.transform.position);
        }
    }
}
