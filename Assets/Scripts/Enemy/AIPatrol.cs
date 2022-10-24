using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    private bool mustPatrol;
    private bool mustFlip;
    public Rigidbody2D rb2d;
    public Transform groundCheckPos;
    public float walkSpeed;
    public LayerMask groundLayer;

    private void Start()
    {
        mustPatrol = true;
    }

    private void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip)
        {
            Flip(); 
        }
        rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, rb2d.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
