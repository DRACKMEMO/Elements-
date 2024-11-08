using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;         // The speed of the dash
    public float dashDuration = 0.2f;     // Duration of the dash in seconds
    public float dashCooldown = 1f;       // Cooldown time between dashes in seconds

    private Rigidbody2D rb;
    private bool isDashing = false;
    private bool canDash = true;
    private Vector2 dashDirection;
    private float dashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerDash script initialized.");
    }

    void Update()
    {
        // Check if dash is available and player presses the dash key
        if (Input.GetKeyDown(KeyCode.Space) && canDash && !isDashing)
        {
            Debug.Log("Dash key pressed, starting dash...");
            StartDash();
        }

        // If currently dashing, check if dash time has ended
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                Debug.Log("Dash time ended, stopping dash.");
                EndDash();
            }
        }
    }

    private Vector2 lastDirection = Vector2.right;  // Default direction to the right

    private void StartDash()
    {
        isDashing = true;
        canDash = false;
        dashTime = dashDuration;

        // Set dash direction based on current player input (or use last direction if no input)
        dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (dashDirection != Vector2.zero)
        {
            lastDirection = dashDirection;  // Update last direction if there�s input
        }
        else
        {
            dashDirection = lastDirection;  // Use the last direction if no new input
            Debug.Log("No new direction detected, using last direction for dash.");
        }

        // Apply dash force
        rb.linearVelocity = dashDirection * dashSpeed;
        Debug.Log($"Player dashed in direction: {dashDirection}, with speed: {dashSpeed}");

        GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(DashCooldown());
    }


    private void EndDash()
    {
        isDashing = false;
        rb.linearVelocity = Vector2.zero;  // Stop the player after dashing

        // Re-enable collision after dash
        GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("Dash ended, player stopped.");
    }

    private System.Collections.IEnumerator DashCooldown()
    {
        Debug.Log("Dash on cooldown...");
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        Debug.Log("Dash cooldown ended, dash ready.");
    }
}
