using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody projectileRB;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    //public int damage;

    public PlayerMovement playerMovement;
    public bool facingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        facingRight = playerMovement.isFacingRight;

        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
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
        if (facingRight)
        {
            projectileRB.linearVelocity = new Vector3(speed, projectileRB.linearVelocity.y);
        }
        else
        {
            projectileRB.linearVelocity = new Vector3(-speed, projectileRB.linearVelocity.y);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}