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
    LevelXPManager levelXPManager;



    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelXPManager = GameObject.FindGameObjectWithTag("LevelXPManager").GetComponent<LevelXPManager>();
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
        yield return new WaitForSeconds(0f);
        gameManager.killCount++;
        Instantiate(destructionEffect, destructionEffectPoint.position, transform.rotation);
        SoundManager.instance.PlayTheSoundEffect(6);
        levelXPManager.XPSpawner(transform);
        levelXPManager.canXpCreated = false;
        DestroyImmediate(gameObject);
        levelXPManager.canXpCreated = true;
        
        
    }
   
    
}
