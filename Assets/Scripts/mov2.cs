using UnityEngine;

public class MovimentacaoWASD : MonoBehaviour
{
    public float xVelocity = 5f;
    public float jumpForce = 12f;
    public Transform opponent;
    private Health health;
    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        // Movimento exclusivo WASD
        moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;

        if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        animator.SetBool("IsGrounded", isGrounded);

        // Pulo com W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Ação com F
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("IsAttacking");
        }
    }

    void FixedUpdate()
    {
        if (health.IsKnocked()) return; // impede sobrescrever o knockback
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * xVelocity, rb.linearVelocity.y);
        AutoFlip();
    }

    void AutoFlip()
    {
        if (opponent == null) return;

        if (transform.position.x < opponent.position.x)
        transform.localScale = new Vector3(1, 1, 1);
        else
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
