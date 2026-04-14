using System.Numerics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody rb;
    private Transform currentPoint;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointA.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        UnityEngine.Vector3 point = currentPoint.position - transform.position;
        if(currentPoint == pointA.transform)
        {
            rb.linearVelocity = new UnityEngine.Vector3(speed, 0);
        }
        else
        {
            rb.linearVelocity = new UnityEngine.Vector3(-speed, 0);
        }

        if(UnityEngine.Vector3.Distance(transform.position, currentPoint.position) < 1.0f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
        
        if (UnityEngine.Vector3.Distance(transform.position, currentPoint.position) < 1.0f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }
    }

    private void flip()
    {
        UnityEngine.Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}