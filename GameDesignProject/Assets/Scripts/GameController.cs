using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject SpawnCollection;
    public GameObject canvas;
    public Text gameStatusText;
    public Text spawnCounterText;
    public Text playerLivesText;

    private GameObject player;

    private Vector3 startPosition;

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

        DontDestroyOnLoad(this.gameObject);//behold gamecontroller når scene er færdig
    }

    public void SetupPlayer(GameObject playerSpawn)
    {
        player = playerSpawn;
        startPosition = playerSpawn.transform.position;
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
                //gameStatusText.text = "You Won";
                //gameStatusText.color = Color.green;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
                player.transform.position = startPosition;
                player.transform.GetChild(0).gameObject.transform.position = new Vector3(0f + startPosition.x, 0f + startPosition.y, 1f);
                return;
            }
            player.SetActive(false);
            gameDone = true;
            gameStatusText.text = "Game Over";
            gameStatusText.color = Color.red;
        }
        
    }
}
