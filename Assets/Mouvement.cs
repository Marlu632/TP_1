using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float jumpForce = 5f;  // Force of the jump
    public float moveSpeed = 1f;  // Normal movement speed
    public float sprintMultiplier = 2f;  // How much faster you move when sprinting
    private bool isGrounded = true;  // Check if the player is on the ground
    private Rigidbody rb;  // Reference to the player's Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    void Update()
    {
        // Determine if the player is sprinting
        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;  // Increase the movement speed when sprinting
        }

        // Movement
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -200 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, 200 * Time.deltaTime);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();  // Call the jump function
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Apply upward force to Rigidbody
        isGrounded = false;  // Player is no longer on the ground
    }

    // Check if the player touches the ground to allow jumping again
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Player can jump again when grounded
        }
    }
}
