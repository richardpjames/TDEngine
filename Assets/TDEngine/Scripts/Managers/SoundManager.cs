using UnityEngine;

namespace richardpjames.com.TDEngine.Managers
{
    [AddComponentMenu("2D Engine/Managers/Sound Manager")]

    public class SoundManager : MonoBehaviour
    {

        private static SoundManager Instance;
        private static AudioSource audioSource;

        private void Awake()
        {
            // Ensure that this is the only instance
            if (Instance == null)
            {
                Instance = this;
                audioSource = GetComponent<AudioSource>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static void Play(AudioClip clip)
        {
            // Simply play the clip on our audio source
            audioSource.PlayOneShot(clip);
        }
    }
}