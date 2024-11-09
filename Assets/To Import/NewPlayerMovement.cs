using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Variables
    public int playerID;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public Animator animator;

    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Check if components are assigned
        if (rb == null) Debug.LogError("Rigidbody2D component not found!");
        if (boxCollider == null) Debug.LogError("BoxCollider2D component not found!");
        if (sr == null) Debug.LogWarning("SpriteRenderer component not found!");
        if (animator == null) Debug.LogWarning("Animator component not found!");
    }

    void Update()
    {
        Move();

        // Handle jumping
        if (IsGrounded())
        {
            if (playerID == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            else if (playerID == 2 && Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        // Trigger attack animation
        if (playerID == 1 && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }
        else if (playerID == 2 && Input.GetKeyDown(KeyCode.RightControl))
        {
            Attack();
        }

        // Set animator parameters
        if (animator != null)
        {
            animator.SetBool("IsGrounded", IsGrounded());
            animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        }
    }

    private void Move()
    {
        Vector2 movement = Vector2.zero;

        // Player 1 controls (AD)
        if (playerID == 1)
        {
            if (Input.GetKey(KeyCode.A)) // Move Left
            {
                movement.x -= 1;
            }
            if (Input.GetKey(KeyCode.D)) // Move Right
            {
                movement.x += 1;
            }
        }

        // Player 2 controls (Arrow Keys)
        if (playerID == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) // Move Left
            {
                movement.x -= 1;
            }
            if (Input.GetKey(KeyCode.RightArrow)) // Move Right
            {
                movement.x += 1;
            }
        }

        // Normalize the movement vector and apply speed
        rb.linearVelocity = new Vector2(movement.normalized.x * moveSpeed, rb.linearVelocity.y);

        // Flip the sprite based on movement direction
        if (movement.x < 0)
        {
            sr.flipX = true; // Flip left
        }
        else if (movement.x > 0)
        {
            sr.flipX = false; // Flip right
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        if (animator != null) animator.SetTrigger("Jump");
    }

    private void Attack()
    {
        if (animator != null) animator.SetTrigger("Attack");
    }

    // Check if player is grounded
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }
}