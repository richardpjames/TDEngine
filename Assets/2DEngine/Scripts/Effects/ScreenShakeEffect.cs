using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("2D Engine/Effects/Effects/Screen Shake")]
public class ScreenShakeEffect : Effect
{
    // Configuration settings for the effect
    [SerializeField] private float amplitude = 10f;
    [SerializeField] private float frequency = 10f;
    [SerializeField] private float duration = 0.25f;
    private bool shaking = false;

    // Run the effect
    public override void Play()
    {
        // Prevent multiple instances of the camera shaking
        if (!shaking)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }
    // Applies the shake effect
    private IEnumerator ShakeCoroutine()
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
