using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMagicBall : MonoBehaviour
{
    [SerializeField] float magicBallSpeed;
    [SerializeField] int magicBallDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(-transform.up * magicBallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            //add Effect
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {   
            //add Effect
            //player take damage
            Destroy(gameObject);
        }
    }

    
}
