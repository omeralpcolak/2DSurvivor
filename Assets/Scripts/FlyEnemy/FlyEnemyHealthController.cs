using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyHealthController : MonoBehaviour
{
    public int flyEnemyCurrentHealth, flyEnemyMaxHealth;
    [SerializeField] GameObject deathEffect, getHitEffect;
    [SerializeField] GameObject effectTxtPrefab;
    [SerializeField] Transform effectTxtPrefabPos;
    GameManager gameManager;
    LevelXPManager levelXPManager;


    private void Awake()
    {
        flyEnemyCurrentHealth = flyEnemyMaxHealth;
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        levelXPManager = GameObject.FindGameObjectWithTag("LevelXPManager").GetComponent<LevelXPManager>();
    }

    public void FlyEnemyTakeDamage(int damage)
    {
        flyEnemyCurrentHealth -= damage;
        Instantiate(effectTxtPrefab, effectTxtPrefabPos.position, effectTxtPrefabPos.rotation);
        Instantiate(getHitEffect, transform.position, transform.rotation);
        //Add sound effect
        if (flyEnemyCurrentHealth <=0)
        {
            StartCoroutine(FlyEnemyDie());
        }
    }

    IEnumerator FlyEnemyDie()
    {
        flyEnemyCurrentHealth = 0;
        Instantiate(effectTxtPrefab, effectTxtPrefabPos.position, effectTxtPrefabPos.rotation);
        yield return new WaitForSeconds(0f);
        gameManager.killCount++;
        Instantiate(deathEffect, transform.position, transform.rotation);
        //Add death sound effect
        SoundManager.instance.PlayTheSoundEffect(10);
        levelXPManager.XPSpawner(transform);
        levelXPManager.canXpCreated = false;
        DestroyImmediate(gameObject);
        levelXPManager.canXpCreated = true;
    }


}
