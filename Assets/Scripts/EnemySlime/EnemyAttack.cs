using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage;
    Animator enemyAnim;
    bool canAttack;
    bool isHitted;
    PlayerHealthController playerHealthController;

    private void Start() 
    {
        playerHealthController = FindObjectOfType<PlayerHealthController>();
        canAttack = false;
        isHitted = false;
        enemyAnim = GetComponent<Animator>();   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            playerHealthController.TakeDamage(enemyDamage);
            StartCoroutine(EnemyAttackRoutine());
            
        }

        if (other.tag == "Projectile")
        {
            StartCoroutine(EnemyGetHitted());
        }

        
    }

    IEnumerator EnemyAttackRoutine()
    {
        canAttack = true;
        enemyAnim.SetBool("canAttack",canAttack);
        yield return new WaitForSeconds(.36f);
        canAttack = false;
        enemyAnim.SetBool("canAttack",canAttack);
    }

    IEnumerator EnemyGetHitted()
    {
        isHitted = true;
        enemyAnim.SetBool("isHitted", isHitted);
        yield return new WaitForSeconds(.20f);
        isHitted = false;
        enemyAnim.SetBool("isHitted", isHitted);

    }

}
