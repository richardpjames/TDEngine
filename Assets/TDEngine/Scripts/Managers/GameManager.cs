using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace richardpjames.com.TDEngine.Managers
{
    [AddComponentMenu("TD Engine/Managers/Game Manager")]

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

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
    }
}