using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D testRb;
    public float speed;
    public float input;
    public SpriteRenderer testRend;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool onGround;
    public Transform feetPos;
    public float groundCheck;

    public float jumpTimer = 0.35f;
    public float jumpTimerCounter;
    private bool isJumping;

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            testRend.flipX = false;
        }
        else if (input > 0)
        {
            testRend.flipX = true;
        }

        onGround = Physics2D.OverlapCircle(feetPos.position, groundCheck, groundLayer);

        if (onGround == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimerCounter = jumpTimer;
            testRb.linearVelocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if(jumpTimerCounter > 0)
            {
                testRb.linearVelocity = Vector2.up * jumpForce;
                jumpTimerCounter -= Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

    }
    
    void FixedUpdate()
    {
        testRb.linearVelocity = new Vector2(input*speed, testRb.linearVelocity.y);
    }
}
