using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    public float maxHealth = 10;
    private bool isHitted=false;
    [SerializeField]private float currentHealth = 10;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] GameObject boingTxtPrefab;
    [SerializeField] GameObject playerDeathEffect;
    Shake shake;
    public float invincibilityTime;
    float invincibilityTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth,currentHealth);
        anim = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }


    private void Update()
    {   







        invincibilityTimer -= Time.deltaTime;
        if (invincibilityTimer<=0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }

    public void TakeDamage(int damageAmount)
    {   
        if (invincibilityTimer<=0)
        {
            currentHealth -= damageAmount;
            StartCoroutine(HitAnimation());
            if (currentHealth <= 0)
            {
                GameManager.instance.gameStart = false;
                StartCoroutine(HitAnimation());
                currentHealth = 0;
                Instantiate(playerDeathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                invincibilityTimer = invincibilityTime;
                sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,.5f );
            }
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
            shake.CamShake();
            StartCoroutine(BoingTxt());
            SoundManager.instance.PlayTheSoundEffect(5);
        }
        
    }

    IEnumerator BoingTxt()
    {
        boingTxtPrefab.SetActive(true);
        yield return new WaitForSeconds(1f);
        boingTxtPrefab.SetActive(false);

    }

    public IEnumerator HitAnimation()
    {
        yield return null;
        isHitted = true;
        anim.SetBool("isHitted", isHitted);
        yield return new WaitForSeconds(.22f);
        isHitted = false;
        anim.SetBool("isHitted", isHitted);
    }
}
