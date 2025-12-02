using System.Collections.Generic;
using UnityEngine;

public class GoblinSpriteManager : MonoBehaviour
{
    public static GoblinSpriteManager Instance { get; private set; }

    [Header("Exactly 4 Goblin Sprites")]
    public List<Sprite> goblinSprites = new List<Sprite>(4);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // remove this if you don't want it to persist between scenes
    }
}