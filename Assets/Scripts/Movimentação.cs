using UnityEngine;

public class Movimentação : MonoBehaviour
{
    public float xVelocity = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private float moveInput;
    private Animator animator;
    private bool facingRight = true;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        animator.SetBool("IsGrounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

    }

    void FixedUpdate()
    {
    rb.linearVelocity = new Vector2(moveInput * xVelocity, rb.linearVelocity.y);

    if(facingRight && moveInput < 0)
            Flip();
    else if(!facingRight && moveInput > 0)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
