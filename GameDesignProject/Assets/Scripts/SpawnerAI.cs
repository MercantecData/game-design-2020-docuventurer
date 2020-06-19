using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    public GameObject Zombie;

    [SerializeField]
    private GameObject player;
    public float startSpawnTime = 1;
    public float spawnRepeatRate = 1;
    public float range = 50;

    void Start()
    {
        InvokeRepeating("SpawnZombie", startSpawnTime, spawnRepeatRate);
    }

    void OnDestroy()
    {
        GameController.instance.SpawnerDied();
    }

    void SpawnZombie()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < range)
        {
            GameObject newZombie = Instantiate(Zombie);

            newZombie.transform.position = transform.position;
        }

        
    }
}
