using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;       // the speed to move the ball at
    public float jumpHeight = 5;  // the amount to jump by per keypress

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private bool shouldJump = false;
    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // ran when an arrow key or WASD key is pressed
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // ran whenever the space bar is pressed
    void OnJump()
    {
        if (jumpCount < 2)
        {
            shouldJump = true;
            jumpCount++;
        }
    }

    // run whenever the ball collides with an object
    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (shouldJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            shouldJump = false;
        }
    }

}
