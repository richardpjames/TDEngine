using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Effects/Effects Container")]

public class EffectsContainer : MonoBehaviour
{
    // This is the list of effects that will be played together
    [SerializeField] private EffectConfiguration[] configurations;

    // This plays all of the effects in the list specified
    public void PlayAll(Vector3 position)
    {
        // Loop through the list of effects and play each of them
        foreach (EffectConfiguration configuration in configurations)
        {
            // Start a co-routine to allow for delays etc.
            StartCoroutine(PlayConfiguration(configuration, position));
        }
    }

    private IEnumerator PlayConfiguration(EffectConfiguration configuration, Vector3 position)
    {
        // Wait for the number of seconds specified in the delay
        yield return new WaitForSeconds(configuration.delay);
        // Play the effect
        configuration.effect.Play(position);
    }


    [Serializable]
    struct EffectConfiguration
    {
        public Effect effect;
        public float delay;
    }
}
