using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody projectileRB;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public EnemyHealth enemyHealth;
    public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;

        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        projectileRB.linearVelocity = new Vector3(speed, projectileRB.linearVelocity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        enemyHealth.TakeDamage(damage);
    }
}