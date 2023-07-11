using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    public List<MagicBase> magics;
    [SerializeField] float projectileCoolDown;
    private bool canAttack;
    UltimateAbility ultimateAbility;
    public int hitCount;
    [SerializeField] int targetHitCount = 20;
    [SerializeField] GameObject ultimateReadyEffect;



    private void Start()
    {
        canAttack = true;
        ultimateAbility = GetComponent<UltimateAbility>();
        hitCount = 0;
        
    }
    private void Update()
    {   
        if (canAttack ==false)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                magics[0].Magic();
                StartCoroutine(ProjectileCoolDown(projectileCoolDown));
            }
            if (hitCount >= targetHitCount)
            {
                ultimateReadyEffect.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    ultimateAbility.UseUltimate();
                    hitCount = 0;
                    ultimateReadyEffect.SetActive(false);
                }
            }

           
        }

        

    }

    IEnumerator ProjectileCoolDown(float cooldown)
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
    
    
    
}
