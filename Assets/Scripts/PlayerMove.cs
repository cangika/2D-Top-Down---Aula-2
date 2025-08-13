using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
        //Local variables can only be used in this method
        Vector3 direction = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow)) direction.y = 1;
        if (Input.GetKeyDown(KeyCode.DownArrow)) direction.y = -1;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction.x = -1;
            // Flip the sprite to face left
            spriteRenderer.flipX = true; // Flip the sprite horizontally
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction.x = 1;
            // Unflip the sprite to face right
            spriteRenderer.flipX = false; // Unflip the sprite horizontally
        }

        //apply the direction to the player's position
        transform.position += direction;

        // Check for collision after moving
        //64 is the layer mask for the "Wall" layer is the 7th layer in Unity (0-indexed)
        Collider2D collision = Physics2D.OverlapCircle(transform.position, 0.1f, 64);
        if (collision != null)
        {
            // If a collision is detected, revert the position
            transform.position -= direction;
            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }
    }
}