using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolZombieAI : MonoBehaviour
{
    private string currentState = "Patrol";
    private Transform nextWaypoint;
    private Vector3 currentTarget;

    public GameObject targetGO;

    public float speed = 5;
    public float range = 15;

    public Transform waypoint1;

    public Transform waypoint2;

    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
        currentTarget = nextWaypoint.position - transform.position;
        transform.right = currentTarget;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (currentState == "Patrol")
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * speed);
            transform.position = nextPosition;

            if (transform.position == nextWaypoint.position)
            {
                if (nextWaypoint == waypoint1)
                {
                    nextWaypoint = waypoint2;
                }
                else
                {
                    nextWaypoint = waypoint1;
                }
            }

            if (TargetAquired())
            {
                currentState = "Attack";
                
            }
            currentTarget = nextWaypoint.transform.position - transform.position;
            transform.right = currentTarget;
        }
        else if (currentState == "Attack")
        {
            if (!TargetAquired())
            {
                currentState = "Patrol";
                
            }
            currentTarget = targetGO.transform.position - transform.position;
            transform.right = currentTarget;

            Vector2 attackPlayerPosition = Vector2.MoveTowards(transform.position, targetGO.transform.position, Time.deltaTime * speed);

            transform.position = attackPlayerPosition;
        }
    }

    bool TargetAquired()
    {
        //GameObject targetGO = GameObject.FindGameObjectWithTag("Player");
        bool inRange = false;
        bool inVision = false;

        if (Vector2.Distance(targetGO.transform.position, transform.position) < range)
        {
            inRange = true;
        }

        var linecast = Physics2D.Linecast(transform.position, targetGO.transform.position, mask);

        if (linecast == false)
        {
            inVision = true;
        }

        return inRange && inVision;

    }
}
