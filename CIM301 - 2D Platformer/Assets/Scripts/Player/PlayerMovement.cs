using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    //[SerializeField] private float fallingForce;
    private bool isFacingRight = true;
    public bool isGrounded;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // Movement
            horizontal = Input.GetAxisRaw("Horizontal");

            // Jumping
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpingPower);
            }

            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(KBCounter <= 0)
        {
            rb.linearVelocity = new Vector3(horizontal * speed, rb.linearVelocity.y);
        }
        else
        {
            if(KnockFromRight == true)
            {
                rb.linearVelocity = new Vector3(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.linearVelocity = new Vector3(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.3f);
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.3f);
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