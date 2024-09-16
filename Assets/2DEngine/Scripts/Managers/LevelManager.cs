using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Managers/Level Manager")]

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] Character playerCharacter;
    [SerializeField] Transform spawnPoint;
    private Character player;

    private void Awake()
    {
        // Ensure that this is the only instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // If the prefab for the player character and the spawn point are defined 
        // then spawn in the character at the beginning of the level
        if (playerCharacter != null && spawnPoint != null)
        {
            ReSpawn();
        }
    }

    public void ReSpawn()
    {
        DetachCamera();
        // Remove the existing player if present
        if (player != null)
        {
            player.Remove();
        }
        // Create a new player
        player = Instantiate(playerCharacter, spawnPoint.position, Quaternion.identity);
        // Attach the camera to the new player
        AttachCamera(player.transform);
    }

    private void DetachCamera()
    {
        // Get the currently active virtual camera
        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
        // Check that we returned a brain
        if (brain != null)
        {
            CinemachineVirtualCamera virtualCamera = (CinemachineVirtualCamera)brain.ActiveVirtualCamera;
            // Check that we have a camera to apply the effect to
            if (virtualCamera != null)
            {
                virtualCamera.Follow = null;
                virtualCamera.LookAt = null;
            }
        }
    }

    private void AttachCamera(Transform target)
    {
        // Get the currently active virtual camera
        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
        // Check that we returned a brain
        if (brain != null)
        {
            CinemachineVirtualCamera virtualCamera = (CinemachineVirtualCamera)brain.ActiveVirtualCamera;
            // Check that we have a camera to apply the effect to
            if (virtualCamera != null)
            {
                virtualCamera.Follow = target;
                virtualCamera.LookAt = target;
            }
        }
    }
}
