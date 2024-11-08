using UnityEngine;

public class Movemove : MonoBehaviour
{
    public float walkspeed = 15f;
    public float Jumpforce = 10f;
    public float AttackDelay = 0.3f;

    private Animator animator;
    private float Xaxis;
    private Rigidbody2D rb; // Changed to Rigidbody2D for 2D physics
    private bool IsJumpPressed = false;
    private bool IsJumping = false; // to track if jump has been initiated
    private int Groundmask;
    private bool IsGrounded;
    private bool IsAttackPressed;
    private bool IsAttacking = false;
    private bool IsBlockPressed;
    private bool IsBlocking = false;
    private string CurrentAnimation;

    // Enum to hold animation states
    private enum State
    {
        ATKair, ATK1, ATK2, ATK3, ATK_SP, ATK_S,
        Death1,
        Defence,
        Hit,
        Idle, Jump, Rolling, Run
    }

    void Start()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Groundmask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input for movement
        Xaxis = Input.GetAxisRaw("Horizontal");

        // Check for key presses
        if (Input.GetKeyDown(KeyCode.Space)) { IsJumpPressed = true; }
        if (Input.GetKeyDown(KeyCode.Q)) { IsAttackPressed = true; }
        if (Input.GetKeyDown(KeyCode.E)) { IsBlockPressed = true; }

        UpdateAnimationState(); // Call to update animations based on input
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, Groundmask);

        // Handle movement based on input
        Vector2 vel = rb.linearVelocity;

        if (Xaxis < 0)
        {
            vel.x = -walkspeed;
            transform.localScale = new Vector2(4, 4); // Flip character to face left
             ChangeAnimation(State.Jump.ToString());
        }
        else if (Xaxis > 0)
        {
            vel.x = walkspeed;
            transform.localScale = new Vector2(-4, 4); ; // Face character right
        }
        else
        {
            vel.x = 0; // Stop horizontal movement
        }

        // Handle jumping
        if (IsJumpPressed && IsGrounded)
        {
            vel.y = Jumpforce;
            IsJumpPressed = false;
            IsJumping = true;
            ChangeAnimation(State.Jump.ToString());
        }

        rb.linearVelocity = vel;

        // Handle attacking
        if (IsAttackPressed && !IsAttacking)
        {
            IsAttackPressed = false;
            IsAttacking = true;
            ChangeAnimation(State.ATK1.ToString());
            Invoke(nameof(AttackComplete), AttackDelay); // Invoke attack completion
        }

        // Handle blocking
        if (IsBlockPressed && !IsBlocking)
        {
            IsBlockPressed = false;
            IsBlocking = true;
            ChangeAnimation(State.Defence.ToString());
        }
    }

    // Function to handle attack completion
    void AttackComplete()
    {
        IsAttacking = false;
        ChangeAnimation(State.Idle.ToString()); // Go back to idle state
    }

    // Function to change animations
    private void ChangeAnimation(string newAnimation)
    {
        if (CurrentAnimation == newAnimation) return; // Avoid re-triggering the same animation
        animator.Play(newAnimation);
        CurrentAnimation = newAnimation;
    }

    // Update animation state based on input
    private void UpdateAnimationState()
    {
        if (IsGrounded && !IsJumping)
        {
            if (Xaxis != 0)
            {
                ChangeAnimation(State.Run.ToString()); // Running animation
            }
            else
            {
                ChangeAnimation(State.Idle.ToString()); // Idle animation
            }
        }

        if (!IsGrounded && IsJumping)
        {
            ChangeAnimation(State.Jump.ToString()); // Jumping animation
        }
    }
}
