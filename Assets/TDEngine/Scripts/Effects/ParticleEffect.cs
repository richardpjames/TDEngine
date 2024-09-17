using UnityEngine;

namespace richardpjames.com.TDEngine.Effects
{
    [AddComponentMenu("TD Engine/Effects/Effects/Particles")]
    public class ParticleEffect : Effect
    {
        // Configuration settings for the effect
        [SerializeField] private GameObject particles;

        // Run the effect
        public override void Play()
        {
            // Do not spawn if particles not specified
            if (particles != null)
            {
                Instantiate(particles, transform.position, transform.rotation);
            }
        }
    }
}