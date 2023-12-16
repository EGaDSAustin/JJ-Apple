using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinRunner : MonoBehaviour
{

    [SerializeField]
    private float JumpForce = 400;
    [SerializeField]
    private float JumpCooldownTime = 0.25f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpInput;
    private bool onJumpCooldown;
    private IEnumerator jumpCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpInput = false;
        onJumpCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump")) 
        {
            jumpInput = true;
        }

    }

    void FixedUpdate()
    {
        if (jumpInput) 
        {
            Jump();
        }

    }

    void Jump() 
    {
        jumpInput = false;
        if (isGrounded && !onJumpCooldown) 
        {
            rb.AddForce(Vector3.up * JumpForce);
            onJumpCooldown = true;

            Debug.Log("Starting jump reset");
            StartCoroutine(ResetJump(JumpCooldownTime));
        }
    }

    IEnumerator ResetJump(float secs) 
    {
        Debug.Log("Jump Reset Started!");
        yield return new WaitForSecondsRealtime(secs);
        onJumpCooldown = false;
        Debug.Log("Jump Reset!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("Exited: " + collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        isGrounded = false;
    }
}
