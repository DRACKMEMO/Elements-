using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f; // Increase this value for a higher jump
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded; // Check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Check for jump input and if the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        Debug.Log("Jump called"); // Log when jump is called
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Use velocity instead of linearVelocity
        isGrounded = false; // Set isGrounded to false after jumping
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player is grounded"); // Log when player is grounded
        }
    }
}