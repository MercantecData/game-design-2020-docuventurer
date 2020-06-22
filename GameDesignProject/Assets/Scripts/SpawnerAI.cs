using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    public GameObject Zombie;

    [SerializeField]
    private GameObject player;
    public float startSpawnTime = 1;
    public float spawnRepeatRate = 2;
    public float range = 30;

    public HealthBar healthBar;

    private int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("SpawnZombie", startSpawnTime, spawnRepeatRate);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            TakeDamage(1);

            if (currentHealth == 0)
            {
                Destroy(this.gameObject);
            }
        }
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
