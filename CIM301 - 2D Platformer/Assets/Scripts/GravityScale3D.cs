using UnityEngine;

public class GravityScale3D : MonoBehaviour
{
    public float gravityScale;
    public static float globalGravity = -9.8f;

    Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}