using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Transform leftPoint, rightPoint;
    bool rightSide;
    Rigidbody2D dragonRb;
    SpriteRenderer sr;


    private void Awake()
    {
        dragonRb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
        rightSide = true;

    }

    private void Update()
    {
        DragonMovementFunc();
    }

    void DragonMovementFunc()
    {
        if(rightSide)
        {
            dragonRb.velocity = new Vector2(movementSpeed, 0);

            sr.flipX = false;

            if (transform.position.x > rightPoint.position.x)
            {
                rightSide = false;
            }
        }
        else
        {
            dragonRb.velocity = new Vector2(-movementSpeed, 0);
            sr.flipX = true;
            if(transform.position.x < leftPoint.position.x)
            {
                rightSide = true;
            }
        }
    }
}
