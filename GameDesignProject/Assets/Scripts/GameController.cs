using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private Text spawnCounterText;
    private Text playerLivesText;

    private GameObject playerSpawn;
    private GameObject gameOverScreen;
    private GameObject levelWonScreen;

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
        DontDestroyOnLoad(this.gameObject);//behold gamecontroller når scene er færdig
    }

    #region Scene setup

    public void HideGameOverScreen(GameObject gameOverScreen)
    {
        instance.gameOverScreen = gameOverScreen;
        instance.gameOverScreen.SetActive(false);
    }

    public void HideLevelWonScreen(GameObject levelWonScreen)
    {
        instance.levelWonScreen = levelWonScreen;
        instance.levelWonScreen.SetActive(false);
    }

    public void SetupSpawnCounter(GameObject spawnCounter)
    {
        instance.SpawnCount = GameObject.FindGameObjectsWithTag("ZombieSpawner").Count();

        spawnCounterText = spawnCounter.GetComponent<Text>();
        spawnCounterText.text = "Spawners left: " + SpawnCount;
    }

    public void SetupPlayerLives(GameObject playerLives)
    {
        playerLivesText = playerLives.GetComponent<Text>();
        playerLivesText.text = "Lives: " + instance.playerLives;
    }

    public void SetupPlayer(GameObject playerSpawn)
    {
        instance.playerSpawn = playerSpawn;
        startPosition = playerSpawn.transform.position;
    }

    #endregion

    public void SpawnerDied()
    {
        SpawnCount--;
        spawnCounterText.text = "Spawners left: " + SpawnCount;

        if (SpawnCount == 0)
        {
            instance.levelWonScreen.SetActive(true);
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
                playerSpawn.transform.position = startPosition;
                playerSpawn.transform.GetChild(0).gameObject.transform.position = new Vector3(0f + startPosition.x, 0f + startPosition.y, 1f);
                return;
            }
            playerSpawn.SetActive(false);
            gameDone = true;
            instance.gameOverScreen.SetActive(true);
        }
        
    }
}
