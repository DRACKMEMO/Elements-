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
        //float moveInput = Input.GetAxis("Horizontal");
        //// Flip sprite based on movement direction
        //if (moveInput != 0)
        //{
        //    sr.flipX = moveInput < 0;
        //}

        Move();

        // Handle jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (animator != null) animator.SetTrigger("Jump");
        }

        // Trigger mouse click animation
        

        // Set animator parameters
        if (animator != null)
        {
            if (IsGrounded())
            {
                animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
            }
            animator.SetBool("IsGrounded", IsGrounded());
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
            if (Input.GetMouseButtonDown(0)) // Left mouse button click
            {
                if (animator != null) animator.SetTrigger("Attack");
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
            if (Input.GetKeyDown(KeyCode.KeypadEnter)) // Left mouse button click
            {
                if (animator != null) animator.SetTrigger("Attack");
            }
        }

        // Normalize the movement vector and apply speed
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    // Check if player is grounded
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }
}