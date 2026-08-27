using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    public ParticleSystem dustEffect;

    private bool wasGroundedLastFrame;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool isGrounded;
    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.y < -10f)
        {
            Debug.Log("Player fell below -10. Respawning...");
            Respawn();
        }

        moveX = Input.GetAxisRaw("Horizontal");

        // Flip sprite
        if (moveX != 0)
            sr.flipX = moveX < 0;

        // Animator values
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalSpeed", rb.linearVelocity.y);

        // Jump input
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button pressed. Coyote time: " + coyoteTimeCounter.ToString("F2"));
        }

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Debug.Log("Jump executed with force: " + jumpForce);
        }

        if (isGrounded)
        {
            if (!wasGroundedLastFrame)
                Debug.Log("Player landed.");

            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (!wasGroundedLastFrame && isGrounded)
        {
            dustEffect.Play();
        }

        wasGroundedLastFrame = isGrounded;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        Collider2D hit = Physics2D.OverlapCircle(groundCheck.position, 0.25f, groundLayer);
        isGrounded = (hit != null);

        if (hit != null)
        {
            Debug.Log("GroundCheck hit: " + hit.gameObject.name);
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        Debug.Log("Player respawned to position: " + respawnPoint.position);
    }
}
