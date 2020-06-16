using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Rigidbody {get; set;}

    [SerializeField]
    private float movementSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x += movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        position.y += movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position = position;
    }
}
