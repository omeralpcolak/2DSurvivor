using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public GameObject destructionEffect;
    public Transform destructionEffectPoint;
    [SerializeField] GameObject slimeParticle;
    [SerializeField] GameObject boomTxtPrefab;
    [SerializeField] Transform boomTxtPos;
    GameManager gameManager;



    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }

    public void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(slimeParticle, transform.position, transform.rotation,transform);
        if (currentHealth <= 0)
        {
            StartCoroutine(EnemyDie());
        }
    }

    IEnumerator EnemyDie()
    {
        currentHealth = 0;
        Instantiate(boomTxtPrefab, boomTxtPos.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);
        gameManager.killCount++;
        Destroy(gameObject);
        Instantiate(destructionEffect, destructionEffectPoint.position, transform.rotation);
    }
   
    
}
