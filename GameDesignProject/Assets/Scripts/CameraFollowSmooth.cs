using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSmooth : MonoBehaviour
{
    public Transform player;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var playerPosition = player.position;
        playerPosition.z = transform.position.z;

        var target = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, .1f);

        transform.position = target;
    }
}
