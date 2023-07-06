using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRB;
    [SerializeField] float enemySpeed;
    public GameObject player;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    private Transform target;
    private void Start() 
    {
        enemyRB = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update() 
    {
        Movement();
    }

    private void Movement()
    {   
        
        directionToPlayer = (target.position - transform.position).normalized;
        enemyRB.velocity = new Vector2 (directionToPlayer.x,0)*enemySpeed;
    }

    private void LateUpdate() 
    {
        if (enemyRB.velocity.x > 0)
        {
            transform.localScale = new Vector3 (localScale.x, localScale.y, localScale.z);
        }
        else if (enemyRB.velocity.x <0)
        {
            transform.localScale = new Vector3 (-localScale.x, localScale.y, localScale.z);
        }
    }

}
