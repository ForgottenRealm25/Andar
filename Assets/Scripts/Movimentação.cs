using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public Transform opponent;
    public float xVelocity = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private float moveInput;
    private Animator animator;
    private Health health;
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
        // Movimento apenas com setas
        moveInput = 0f;
        if (health != null && health.IsKnocked())
            return;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveInput = -1f;

        if (Input.GetKey(KeyCode.RightArrow))
            moveInput = 1f;

        animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        animator.SetBool("IsGrounded", isGrounded);

        // Pulo com seta para cima
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Ação com Numpad1
        if (Input.GetKeyDown(KeyCode.Keypad1))
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
