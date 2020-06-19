using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject SpawnCollection;
    public GameObject canvas;
    public Text gameStatusText;
    public Text spawnCounterText;
    
    private int SpawnCount;
    private bool gameDone = false;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        instance.SpawnCount = SpawnCollection.transform.childCount;
        spawnCounterText.text = "Spawners left:" + SpawnCount;
    }

    public void SpawnerDied()
    {
        SpawnCount--;
        spawnCounterText.text = "Spawners left:" + SpawnCount;

        if (SpawnCount == 0)
        {
            if (!gameDone)
            {
                gameDone = true;
                gameStatusText.text = "You Won";
                gameStatusText.color = Color.green;
            }
            
        }
    }

    public void PlayerDied()
    {
        if (!gameDone)
        {
            gameDone = true;
            gameStatusText.text = "Game Over";
            gameStatusText.color = Color.red;
        }
        
    }
}
