using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlyEnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject flyEnemyMagicBall;

    public float instantiateTimer = 1f;

    private void FixedUpdate()
    {   
        if (GameManager.instance.gameStart)
        {
            instantiateTimer -= Time.deltaTime;
            if (instantiateTimer <= 0)
            {
                Instantiate(flyEnemyMagicBall, transform.position, transform.rotation);


                instantiateTimer = 1f;
            }
        }
        
    }
}
