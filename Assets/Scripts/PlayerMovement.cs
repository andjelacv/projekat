using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float dirx;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpFloat = 14f;

    private enum MovementState {idle,running,jumping,falling};
    

    // Start is called before the first frame update
   private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
        collider= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity= new Vector2(dirx*moveSpeed,rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpFloat);
        }

        Animate();

        
    }


    private void Animate()
    {

        MovementState state;

        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state=MovementState.running;
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
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);


    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }


}
