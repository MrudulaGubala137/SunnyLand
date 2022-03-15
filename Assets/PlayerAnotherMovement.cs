using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnotherMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed = 5f;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;
    public float jumpForce;
    public bool isGrounded=true; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("isRunning", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToJump();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
        
    }

    private void ToJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, movement.y * jumpForce);
        animator.SetBool("isJump", true);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
}
