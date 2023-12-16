using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinRunner : MonoBehaviour
{

    [SerializeField]
    private float JumpForce = 400;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpInput = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump")) 
        {
            jumpInput = true;
            Debug.Log("Received jump input");
        }

    }

    void FixedUpdate()
    {
        if (jumpInput) 
        {
            Jump();
            Debug.Log("Starting jump event");
        }

    }

    void Jump() 
    {
        jumpInput = false;
        if (isGrounded) rb.AddForce(Vector3.up * JumpForce);
        Debug.Log("Jump completed");
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
