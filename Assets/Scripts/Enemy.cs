using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour{

    [Header("Enemy Characteristics")]
    public float startSpeed = 10f;
    public float health = 100;
    private float startHealth;
    public int value = 50; //enemy value in cash

    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    public Image healthBar;

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
