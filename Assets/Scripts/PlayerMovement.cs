using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collin;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private AudioSource croak;
    private enum MovementState { idle, running, aim, falling, jumping, croaker }
    private MovementState state;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collin = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movements();

    }

    private void Movements()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (hori * moveSpeed, rb.velocity.y);

        MovementState state;
            
            if (hori > 0)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (hori < 0)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            


            else if (rb.velocity.y < -.9f)
            {
                state = MovementState.falling;
            }


            
        anim.SetInteger("state", (int)state);


        if (Input.GetButtonDown("Jump"))
        {
            croak.Play();
            state = MovementState.croaker;
        }
        else
        {

        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(collin.bounds.center, collin.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    
    

}
