using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMagicBall : MonoBehaviour
{
    [SerializeField] float magicBallSpeed;
    [SerializeField] int magicBallDamage;
    [SerializeField] GameObject effectPrefab;
    Shake shake;

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
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


        if (other.tag == "Player")
        {
            Instantiate(effectPrefab, transform.position, transform.rotation);
            SoundManager.instance.PlayTheSoundEffect(9);
            shake.CamShake();
            other.GetComponent<PlayerHealthController>().TakeDamage(magicBallDamage);
            Destroy(gameObject);
        }

        if (other.tag == "Ground")
        {
            shake.CamShake();
            Instantiate(effectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }

       
    }

    
}
