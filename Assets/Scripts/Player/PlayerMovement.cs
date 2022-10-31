using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    public BoxCollider2D boxCollider;
    public BoxCollider2D crouchCollider;
    public Transform player;
    //private float wallJumpCooldown;
    private float horizontalInput;
    public int extraJumps;
    private bool crouching;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 2, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 2, 1);

        //Crouch
        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouch();
        }
        if(crouching == true)
        {
            player.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
         body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }
        if (onWall())
        {
           //body.gravityScale = 0;
           // body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 1.5f;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            //wallJumpCooldown = 0;
        }
    }

    private void Crouch()
    {
        if (isGrounded() && !onWall() && crouching == false)
        {
            boxCollider.enabled = false;
            crouchCollider.enabled = true;
            crouching = true;
            player.localScale =  new Vector3(transform.localScale.x, 1, transform.localScale.z);
        }
        else
        {
            crouching = false;
            boxCollider.enabled = true;
            crouchCollider.enabled = false;
            player.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
        }
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return isGrounded() && !onWall();
    }
}
