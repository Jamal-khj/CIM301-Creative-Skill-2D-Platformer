using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

  //  public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            playerMovement.enabled = false;
            Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}