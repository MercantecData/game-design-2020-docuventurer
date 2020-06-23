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
    public Text playerLivesText;

    [SerializeField]
    private GameObject player;

    private int playerLives = 3;
    
    private int SpawnCount;
    private bool gameDone = false;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        instance.SpawnCount = SpawnCollection.transform.childCount;
        spawnCounterText.text = "Spawners left: " + SpawnCount;
        playerLivesText.text = "Lives: " + playerLives;
    }

    public void SpawnerDied()
    {
        SpawnCount--;
        spawnCounterText.text = "Spawners left: " + SpawnCount;

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
            playerLives -= 1;
            playerLivesText.text = "Lives: " + playerLives;

            if (playerLives > 0)
            {
                player.transform.position = new Vector3(-6.38f, 2.86f, 0);
                player.transform.GetChild(0).gameObject.transform.position = new Vector3(-6.38f, 2.86f, 0);
                return;
            }
            player.SetActive(false);
            gameDone = true;
            gameStatusText.text = "Game Over";
            gameStatusText.color = Color.red;
        }
        
    }
}
