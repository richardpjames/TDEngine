
using Richardpjames.TDEngine.Managers;
using UnityEngine;

namespace Richardpjames.TDEngine.Effects
{
    [AddComponentMenu("2D Engine/Effects/Effects/Screen Shake")]
    public class ScreenShakeEffect : Effect
    {
        // Configuration settings for the effect
        [SerializeField] private float amplitude = 10f;
        [SerializeField] private float frequency = 10f;
        [SerializeField] private float duration = 0.25f;
        [SerializeField] private int priority = 1;

        // Run the effect
        public override void Play()
        {
            // Shake through the camera manager
            CameraManager.Instance.Shake(amplitude, frequency, duration, priority);
        }
    }
}