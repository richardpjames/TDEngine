using richardpjames.com.TDEngine.Managers;
using UnityEngine;

namespace richardpjames.com.TDEngine.Effects
{
    [AddComponentMenu("2D Engine/Effects/Effects/Sound")]
    public class SoundEffect : Effect
    {
        // Configuration settings for the effect
        [SerializeField] private AudioClip sound;

        // Run the effect
        public override void Play()
        {
            // Do not spawn if sound not specified
            if (sound != null)
            {
                SoundManager.Play(sound);
            }
        }
    }
}