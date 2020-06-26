using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieAI : MonoBehaviour
{
    private Vector3 currentTarget;

    private GameObject Player;

    public float speed = 5;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var linecast = Physics2D.Linecast(transform.position, Player.transform.position, mask);

        if (linecast == false)
        {
            Vector2 attackPlayerPosition = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * speed);

            transform.position = attackPlayerPosition;

            currentTarget = Player.transform.position - transform.position;
            transform.right = currentTarget;
        }

        
    }
}
