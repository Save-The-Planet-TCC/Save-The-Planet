using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    private float speedX, speedY;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isMoving;
    private Vector2 input;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            input = input.normalized;
        }

        speedX = input.x * movSpeed;
        speedY = input.y * movSpeed;

        Debug.Log("This is input.x: " + speedX);
        Debug.Log("This is input.y: " + speedY);

        if(speedY != 0 || speedX != 0)
        {
            animator.SetFloat("moveX", speedX);
            animator.SetFloat("moveY", speedY);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        };

        animator.SetBool("isMoving", isMoving);


        rb.velocity = new Vector2(speedX, speedY);
    }
}
