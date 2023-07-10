using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public GameObject destructionEffect;
    public Transform destructionEffectPoint;
    [SerializeField] GameObject slimeParticle;



    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {   
     
        
    }

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(slimeParticle, transform.position, transform.rotation,transform);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            Instantiate(destructionEffect, destructionEffectPoint.position, transform.rotation);
        }
    }

    

    
}
