using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    public GameObject Zombie;
    public float startSpawnTime = 10;
    public float spawnRepeatRate = 5;

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
        GameObject newZombie = Instantiate(Zombie);

        newZombie.transform.position = transform.position;
    }
}
