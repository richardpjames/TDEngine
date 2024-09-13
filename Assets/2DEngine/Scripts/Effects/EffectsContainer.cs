using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Effects/EffectsContainer")]

public class EffectsContainer : MonoBehaviour
{
    // This is the list of effects that will be played together
    [SerializeField] private EffectConfiguration[] configurations;

    // This plays all of the effects in the list specified
    void PlayAll()
    {
        // Loop through the list of effects and play each of them
        foreach (EffectConfiguration configuration in configurations)
        {
            // Start a co-routine to allow for delays etc.
            StartCoroutine(PlayConfiguration(configuration));
        }
    }

    private IEnumerator PlayConfiguration(EffectConfiguration configuration)
    {
        // Wait for the number of seconds specified in the delay
        yield return new WaitForSeconds(configuration.delay);
        // Play the effect
        configuration.effect.Play();
    }


    [Serializable]
    struct EffectConfiguration
    {
        public Effect effect;
        public float delay;
    }
}
