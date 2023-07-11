using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class UltimateAbility : MonoBehaviour
{
    public GameObject ultimateEffect;
    [SerializeField] Transform ultimatePosition;
    int ultimateDamage = 10;
    Shake shake;
    PlayerMovement playerMovement;
    
    
    
    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void UseUltimate()
    {
        StartCoroutine(ActivateUltimate());
    }

    public IEnumerator ActivateUltimate()
    {
        playerMovement.canItMove = false;
        transform.DOMoveY(ultimatePosition.position.y,1);
        yield return new WaitForSeconds(1f);
        playerMovement.canItMove = true;
        Instantiate(ultimateEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.20f);
        shake.UltimaShake();
        GameObject[] slimes = GameObject.FindGameObjectsWithTag("Slime");

        foreach (GameObject slime in slimes)
        {   
            
            slime.GetComponent<EnemyHealthController>().EnemyTakeDamage(ultimateDamage);
        }
    }
}
