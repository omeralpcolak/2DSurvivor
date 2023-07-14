using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class XPController : MonoBehaviour
{
    public float xpValue = 10;

    PlayerMovement playerMovement;
    LevelXPManager levelXPManager;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        levelXPManager = GameObject.FindGameObjectWithTag("LevelXPManager").GetComponent<LevelXPManager>();
    }

    private void Update()
    {
        MovementToPlayer();
    }

    private void MovementToPlayer()
    {
        transform.DOMove(playerMovement.transform.position,1.2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            SoundManager.instance.PlayTheSoundEffect(8);
            Destroy(gameObject);
            levelXPManager.currentXp += xpValue;
            levelXPManager.UpdateXpBar();
        }
    }

}
