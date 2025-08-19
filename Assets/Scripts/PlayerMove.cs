using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 moveDirection;
    public Rigidbody2D rb;
    //Global variables can be used in any method in this class
    SpriteRenderer spriteRenderer; //SpriteRenderer to change the player's sprite

    private void Start()
    {
        //Initialize the spriteRenderer variable
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to the player object
        if (spriteRenderer == null)
        {
            Debug.LogError("Are you sure this is a sprite?");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;


        // Check for collision after moving
        //64 is the layer mask for the "Wall" layer is the 7th layer in Unity (0-indexed)
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 0.1f, 64);
        if (collision != null)
        {

            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}