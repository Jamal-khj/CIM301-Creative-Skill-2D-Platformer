using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private float fallingForce;
    private bool isFacingRight = true;
    public bool isGrounded;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * fallingForce);
            }

            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.2f);
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.2f);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}