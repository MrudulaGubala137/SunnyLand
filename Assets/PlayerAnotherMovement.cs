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
    private bool isGrounded=true; 
    SpriteRenderer spriteRenderer;
    public int score;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        if(movement.x >0)
        {
            spriteRenderer.flipX = false;
        }
        else if(movement.x <0)
        {
            spriteRenderer.flipX = true;
        }
        
        animator.SetFloat("isRunning", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded==true)
        {
            ToJump();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x*playerSpeed, rb.velocity.y);
        
    }

    private void ToJump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        animator.SetBool("isJump", true);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            animator.SetBool("isJump", false);

        }
       
    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Gem")
        {
            score = score + 10;
            Destroy(gameObject);
            Debug.Log(score);
        }
    }
   
}
