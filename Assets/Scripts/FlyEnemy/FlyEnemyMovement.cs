using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyEnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRB;
    [SerializeField] float enemySpeed;
    [SerializeField] Transform yPos;
    public GameObject player;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    private Transform target;
    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        target = GameObject.FindWithTag("Player").transform;
        transform.DOMoveY(yPos.position.y,2f);
    }

    private void Update()
    {
        if (GameManager.instance.gameStart)
        {
            Movement();
        }
        else
        {
            StopFlyEnemyMovement();
        }

        

    }

    private void Movement()
    {

        directionToPlayer = (target.position - transform.position).normalized;
        enemyRB.velocity = new Vector2(directionToPlayer.x, 0) * enemySpeed;
    }

    private void LateUpdate()
    {
        if (enemyRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(+localScale.x, localScale.y, localScale.z);
        }
        else if (enemyRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    private void StopFlyEnemyMovement()
    {
        enemyRB.velocity = new Vector2(0, 0);
    }

}
