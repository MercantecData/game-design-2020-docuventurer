using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Rigidbody {get; set;}

    private Animator animator;

    private float dirX;
    private float dirY;

    [SerializeField]
    private float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dirX = movementSpeed;
        dirY = movementSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x += movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        position.y += movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position = position;

        SetAnimationState();

        dirX = movementSpeed * Input.GetAxis("Horizontal");
        dirY = movementSpeed * Input.GetAxis("Vertical");
    }

    void SetAnimationState()
    {
        if (Mathf.Abs(dirX) > 2 || Mathf.Abs(dirY) > 2)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
