using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectileSpeed;
    private int direction;
    [SerializeField] GameObject explosionEffect;
    [SerializeField]public int projectileDamage;
    //EnemyHealthController enemyHealthController;
    bool hasHit;

    Shake shake;


    private void Awake()
    {
        
    }

    private void Start()
    {
        //enemyHealthController = FindObjectOfType<EnemyHealthController>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Slime" && !hasHit )
        {
            hasHit = true;
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            other.GetComponent<EnemyHealthController>().EnemyTakeDamage(projectileDamage);
            shake.CamShake();
        }
    }

    private void FixedUpdate()
    {
        if (direction == 0)
        {
            Debug.Log("direction is zero!");
        }
        else
        {
            transform.Translate(-direction * transform.right * projectileSpeed * Time.deltaTime);
        }
    }


    public void Init(bool playerFacingRight)
    {
        direction = playerFacingRight ? 1 : -1;
        hasHit = false;
    }
    
    public void Init()
    {
        direction = 0;
        hasHit = false;
    }
}
