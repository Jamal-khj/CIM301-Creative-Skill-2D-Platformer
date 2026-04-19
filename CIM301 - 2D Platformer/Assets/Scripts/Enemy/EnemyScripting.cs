using UnityEngine;

public class EnemyScripting : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;
    public PlayerMovement playerMovement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            
            if(collision.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }

            if (collision.transform.position.x >= transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }

            playerHealth.TakeDamage(damage);
        }
    }
}