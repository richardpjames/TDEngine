using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("2D Engine/Managers/Game Manager")]

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameStyle { TopDown, SideScrolling }
    [SerializeField] private GameStyle style;

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
    // Get the style of game being run
    public GameStyle GetStyle()
    {
        return style;
    }
}
