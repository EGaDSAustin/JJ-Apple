using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinRunner : MonoBehaviour
{
    [Header("Jump Settings")] 
    [SerializeField] float JumpForce = 10;
    [SerializeField] float ContinuousJumpForce = 2;
    [SerializeField] float FallForce = 2;
    [SerializeField] float JumpCooldownTime = 0.25f;
    [SerializeField] float JumpTime = 1.0f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpPressed;
    private bool jumpHeld;
    private bool isJumping;
    private bool onJumpCooldown;
    private Vector2 gravVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        jumpPressed = false;
        jumpHeld = false;
        isJumping = false;
        onJumpCooldown = false;
        gravVector = new Vector2(0, -Physics2D.gravity.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump")) 
        {
            jumpPressed = true;
            jumpHeld = true;
            Jump();
        }

        if (Input.GetButtonUp("Jump")) 
        {
            jumpPressed = false;
            jumpHeld = false;
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed) 
        {
            jumpPressed = false;
            Jump();
        }

        if (rb.velocity.y < 0) 
        {
            rb.AddForce(Vector2.down * FallForce);
        } else if (rb.velocity.y > 0) 
        {
            if (!jumpHeld) {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            } else if (isJumping) 
            {
                rb.AddForce(Vector2.up * ContinuousJumpForce);
            }
        }
    }

    void Jump() 
    {

        if (isGrounded && !onJumpCooldown) 
        {
            rb.AddForce(Vector2.up * JumpForce);
            onJumpCooldown = true;
            isJumping = true;
            StartCoroutine(ResetJump(JumpCooldownTime));
            StartCoroutine(StopJump(JumpTime));
        }
    }

    IEnumerator ResetJump(float secs) 
    {
        yield return new WaitForSecondsRealtime(secs);
        onJumpCooldown = false;
        Debug.Log("Jump Reset!");
    }

    IEnumerator StopJump(float secs)
    {
        yield return new WaitForSecondsRealtime(secs);
        isJumping = false;
        Debug.Log("Jump stopped!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited: " + collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
