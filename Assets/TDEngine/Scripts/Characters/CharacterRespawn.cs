using richardpjames.com.TDEngine.Characters;
using System;
using System.Collections;
using UnityEngine;

namespace richardpjames.com.TDEngine.Characters
{
    [AddComponentMenu("TD Engine/Characters/Character Respawn")]

    public class CharacterRespawn : MonoBehaviour
    {
        [SerializeField] private float cooldown;
        private Vector3 spawnPoint;
        public Action OnRespawn;

        // Start is called before the first frame update
        void Start()
        {
            spawnPoint = transform.position;
        }

        public void ReSpawn()
        {
            // Allow any components to reset themselves
            OnRespawn?.Invoke();
            // Reset the character back to the start point
            transform.position = spawnPoint;
            // Disable and then re-enable the game object
            InvokeRepeating("ToggleEnabled", 0f, cooldown);
        }

        // Toggle whether the gameobject is enabled
        private void ToggleEnabled()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            // If setting back to active then cancel the invoke
            if (gameObject.activeSelf)
            {
                CancelInvoke();
            }
        }

    }
}
