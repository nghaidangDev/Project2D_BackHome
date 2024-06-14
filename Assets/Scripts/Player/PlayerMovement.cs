using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //move
    [SerializeField] private float speed;
    private float horizontal;

    //jump
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //double jump
    private bool doubleJump;

    //Flip
    private bool isFacingRight;

    private Rigidbody2D rb;
    private Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        Jumping();
        Flip();
    }

    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetBool("run", horizontal != 0);
    }

    private void Jumping()
    {
        if (!Input.GetKey(KeyCode.Space) && isGrounded())
        {
            doubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetTrigger("jump");
                if (doubleJump)
                {
                    anim.SetTrigger("doubleJump");
                }

                doubleJump = !doubleJump;
            }
        }


        if (rb.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.up, -0.5f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal > 0) || (!isFacingRight && horizontal < 0))
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
