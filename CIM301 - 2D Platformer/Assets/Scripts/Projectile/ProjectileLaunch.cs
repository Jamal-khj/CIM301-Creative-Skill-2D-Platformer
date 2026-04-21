using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootCount = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && shootCount <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCount = shootTime;
        }

        shootCount -= Time.deltaTime;
    }
}