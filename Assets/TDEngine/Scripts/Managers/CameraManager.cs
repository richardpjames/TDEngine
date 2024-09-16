using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

namespace Richardpjames.TDEngine.Managers
{
    [AddComponentMenu("2D Engine/Managers/Camera Manager")]

    public class CameraManager : MonoBehaviour
    {
        public static CameraManager Instance;
        private bool shaking = false;
        private Coroutine runningRoutine;
        private float currentPriority = 0;

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

        // Handles all screen shaking to manage multiple requests at once
        public void Shake(float amplitude, float frequency, float duration, int priority = 1)
        {
            // If this request is for a shake with a higher priority 
            if (shaking && priority > currentPriority)
            {
                // Stop the current coroutine
                StopCoroutine(runningRoutine);
                // Set shaking to false to allow the next one to trigger
                shaking = false;
            }
            // Check that the camera is not already shaking
            if (!shaking)
            {
                // Store the current priority
                currentPriority = priority;
                // Start the coroutine to shake the camera
                runningRoutine = StartCoroutine(ShakeCoroutine(amplitude, frequency, duration));
            }

        }

        // Applies the shake effect
        private IEnumerator ShakeCoroutine(float amplitude, float frequency, float duration)
        {
            // Set that we are shaking
            shaking = true;
            // Get the currently active virtual camera
            CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
            // Check that we returned a brain
            if (brain != null)
            {
                CinemachineVirtualCamera virtualCamera = (CinemachineVirtualCamera)brain.ActiveVirtualCamera;
                // Check that we have a camera to apply the effect to
                if (virtualCamera != null)
                {
                    // Get the noise component from CineMachine
                    CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    // Check that there was noise returned
                    if (noise != null)
                    {
                        // Up the frequency and amplitude for the duration
                        noise.m_AmplitudeGain = amplitude;
                        noise.m_FrequencyGain = frequency;
                        yield return new WaitForSeconds(duration);
                        // Reset back to zero to steady the camera
                        noise.m_AmplitudeGain = 0;
                        noise.m_FrequencyGain = 0;
                        // Reset the camera rotation
                        Camera.main.transform.rotation = Quaternion.identity;
                    }
                    else
                    {
                        // Thrown when no noise was found
                        throw new Exception("No noise assigned to virtual camera.");
                    }
                }
                else
                {
                    // Thrown when the brain was found, but no camera is active
                    throw new Exception("No active virtual camera found.");
                }
            }
            else
            {
                // Thrown when there is no cinemachine brain on the main camera
                throw new Exception("Could not find CineMachine brain.");
            }
            // Set that we are no longer shaking
            shaking = false;
        }
    }
}