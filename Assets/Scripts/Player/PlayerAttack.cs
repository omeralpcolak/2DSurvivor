using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public List<MagicBase> magics;
    [SerializeField] float projectileCoolDown;
    private bool canAttack;
    UltimateAbility ultimateAbility;
    



    private void Start()
    {
        canAttack = true;
        ultimateAbility = GetComponent<UltimateAbility>();
        
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
            if (Input.GetKeyDown(KeyCode.R))
            {
                ultimateAbility.UseUltimate();
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
