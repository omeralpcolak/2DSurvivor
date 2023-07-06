using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    Animator anim;
    public float maxHealth = 10;
    [SerializeField]private float currentHealth = 10;
    [SerializeField] private Healthbar healthbar;
    Shake shake;
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth,currentHealth);
        anim = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }


    private void Update()
    {
        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
        shake.CamShake();
    }


    

}
