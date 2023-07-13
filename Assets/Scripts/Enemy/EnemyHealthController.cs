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
        Instantiate(boomTxtPrefab, boomTxtPos.position, Quaternion.identity);
        Instantiate(slimeParticle, transform.position, transform.rotation,transform);
        SoundManager.instance.PlayTheSoundEffect(7);
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
        SoundManager.instance.PlayTheSoundEffect(6);
        Instantiate(destructionEffect, destructionEffectPoint.position, transform.rotation);
    }
   
    
}
