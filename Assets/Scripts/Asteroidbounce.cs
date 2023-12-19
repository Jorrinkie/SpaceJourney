using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidbounce : MonoBehaviour
{
    public float speedX = 3.0f; // Adjust the horizontal speed as needed
    public float speedY; // Adjust the vertical speed as needed
    public float maxXPosition = 8.0f; // Adjust the maximum X position
    public float minXPosition = -8.0f; // Adjust the minimum X position
    public float maxYPosition = 3.0f; // Adjust the maximum Y position
    public float minYPosition = -3.0f; // Adjust the minimum Y position

    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(-1, 1); // Start moving left and up

    private void Start()
    {
        speedY = 1 * Random.Range(-3, 3);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the asteroid is at the left or right camera bounds
        if (transform.position.x >= maxXPosition || transform.position.x <= minXPosition)
        {
            // Reverse the X direction to bounce off
            direction.x *= -1;
        }

        // Check if the asteroid is at the upper or lower camera bounds
        if (transform.position.y >= maxYPosition || transform.position.y <= minYPosition)
        {
            // Reverse the Y direction to bounce off
            direction.y *= -1;
        }
    }

    private void FixedUpdate()
    {
        // Move the asteroid in the current direction
        rb.velocity = new Vector2(speedX * direction.x, speedY * direction.y);
    }
}
