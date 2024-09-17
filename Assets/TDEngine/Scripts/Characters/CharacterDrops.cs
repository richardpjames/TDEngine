using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDrops : MonoBehaviour
{
    [SerializeField] private int chanceOfDrop;
    [SerializeField] private GameObject[] drops;

    public void Drop()
    {
        // Roll a random number to determine if we drop anything
        int random = Random.Range(0, 100);
        // If drop allowed and there are drops specified
        if(random < chanceOfDrop && drops.Length > 0)
        {
            int drop = Random.Range(0,drops.Length);
            // Instantiate a random drop from the table
            Instantiate(drops[drop], transform.position, Quaternion.identity);
        }

    }
}
