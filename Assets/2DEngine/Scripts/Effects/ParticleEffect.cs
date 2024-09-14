using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("2D Engine/Effects/Effects/Particles")]
public class ParticleEffect : Effect
{
    // Configuration settings for the effect
    [SerializeField] private ParticleEffect particles;

    // Run the effect
    public override void Play(Vector3 position)
    {
        // Do not spawn if particles not specified
        if (particles != null)
        {
            Instantiate(particles, position, Quaternion.identity);
        }
    }
}
