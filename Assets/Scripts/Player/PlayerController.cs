using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed; 
    public Vector2 jumpHeight;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && grounded)
        {
            SlideLeft();
        }else
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && grounded)
        {
            SlideRight();
        }else 
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
        {
            float xMove = Input.GetAxis("Horizontal");

            Vector2 newPosition = transform.position;

            newPosition.x += xMove * playerSpeed * Time.deltaTime;

            transform.position = new Vector2(newPosition.x, newPosition.y);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Ground"))
        {
            grounded = true;
        }
    }
    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        grounded = false;
    }

    private void SlideLeft()
    {

    }

    private void SlideRight()
    {

    }
}
