using System.Collections;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;

    IEnumerator Start()
    {
        Transform target = pointA;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) <= 0)
            {
                target = target == pointA ? pointB : pointA;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}