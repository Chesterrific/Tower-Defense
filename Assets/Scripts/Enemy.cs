using UnityEngine;

public class Enemy : MonoBehaviour{

    [Header("Enemy Characteristics")]
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100;
    public int value = 50; //enemy value

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }
    //Reduces enemy object's health.
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject deathEF = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEF, 4f);

        Destroy(gameObject);
        
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}	
