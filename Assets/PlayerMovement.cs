using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpForce;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
     rb=GetComponent<Rigidbody2D>(); 
        animator=GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("isRunning",movement.sqrMagnitude);
       
       

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+ movement * playerSpeed*Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(new Vector2(0f,movement.y*jumpForce),ForceMode2D.Impulse);
            animator.SetBool("isJump", true);

        }
    }
}
